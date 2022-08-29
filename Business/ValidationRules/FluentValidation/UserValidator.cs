﻿
using Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<AuthDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad Soyad kısmı boş geçilemez!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş geçilemez!");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Doğru bir mail adresi giriniz.!");
            RuleFor(x => x.ImageUrl).NotNull().WithMessage("ImageURl boş geçme!");
            RuleFor(x => x.Password).NotNull().WithMessage("Şifre boş geçemez!");
            RuleFor(x => x.Password).MinimumLength(6).WithMessage("Şifreniz en az 6 karakter olmalıdır.");

        }
    }
}
