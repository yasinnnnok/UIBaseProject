
using Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class AuthValidator:AbstractValidator<AuthDto>
    {
        public AuthValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("User boş geçilemez.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş geçilemez!");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Doğru bir mail adresi giriniz.!");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("ImageURl boş geçme!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş geçemez!");
            RuleFor(x => x.Password).MinimumLength(6).WithMessage("Şifreniz en az 6 karakter olmalıdır.");
            RuleFor(x => x.Password).Matches("[A-Z]").WithMessage("Şifreniz e az 1 adet büyük harf içermelidir.");
            RuleFor(x => x.Password).Matches("[a-z]").WithMessage("Şifreniz en az 1 adet küçük harf içermelidir.");
            RuleFor(x => x.Password).Matches("[0-9]").WithMessage("Şifreniz en az 1 adet sayı içermelidir.");
            RuleFor(x => x.Password).Matches("[^a-zA-Z0-9]").WithMessage("Şifreniz en az 1 adet özel karakter içermelidir.");
   

        }
    }
}
