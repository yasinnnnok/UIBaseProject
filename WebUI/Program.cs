using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolves.Autofac;
using Business.ValidationRules.FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddControllersWithViews()
    .AddFluentValidation(configration => configration.RegisterValidatorsFromAssemblyContaining<AuthValidator>());

//Autofac ile DependencyInjection ekleme
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));


builder.Services.AddHttpClient();

//JWT
//ValidateAudience- hangi sitelerin kontrol etmesi
//ValidateIssuer-oluþturacak tokeni kimin daðýttýðýný
//ValidateLifetime-belli sonra süre bitsin. bitme süresi olsunmu. 
//ValidateIssuerSigningKey - üreteceðk token deðerinin uygulamamýza ait old. doðrulamasýdýr.
//ClockSkew->server ile saat farký olursa

//.AddCookie(opt =>
//{
//    opt.LoginPath = "/Auth/login";
//    opt.LogoutPath = "/Auth/Logout";
//    opt.AccessDeniedPath = "/Auth/AccessDenied";
//    opt.Cookie.SameSite = SameSiteMode.Strict;
//    opt.Cookie.HttpOnly = true;
//    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
//    opt.Cookie.Name = "JwtCookie";
//})
builder.Services.AddSession();
builder.Services.AddMvc();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)

.AddJwtBearer(options =>
    {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "https://localhost:7043",
        ValidAudience = "https://localhost:7043",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysecuritkeymysecuritkey1002")),
        ClockSkew = TimeSpan.Zero

    };

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

//
app.UseSession();

app.Use(async (context, next) =>
{
    var token = context.Session.GetString("Token");
    if (!string.IsNullOrEmpty(token))
    {
        context.Request.Headers.Add("Authorization", "Bearer " + token);
    }
    await next();
});

//();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");




app.Run();



