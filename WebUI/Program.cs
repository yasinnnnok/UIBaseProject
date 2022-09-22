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
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddFluentValidation(configration => configration.RegisterValidatorsFromAssemblyContaining<AuthValidator>());



//Autofac ile DependencyInjection ekleme
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder=>builder.RegisterModule(new AutofacBusinessModule()));



//JWT
//ValidateAudience- hangi sitelerin kontrol etmesi
//ValidateIssuer-oluþturacak tokeni kimin daðýttýðýný
//ValidateLifetime-belli sonra süre bitsin. bitme süresi olsunmu. 
//ValidateIssuerSigningKey - üreteceðk token deðerinin uygulamamýza ait old. doðrulamasýdýr.
//ClockSkew->server ile saat farký olursa
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)  
    .AddCookie(opt =>
    {
        opt.Cookie.Name = ".NetCoreMvc.Auth";
        opt.LoginPath = "/Auth/Login";
        opt.AccessDeniedPath = "/Auth/Login";


    })    
    .AddJwtBearer(options =>
{
    //?
   
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "http://localhost",
        ValidAudience = "http://localhost",
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
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();
