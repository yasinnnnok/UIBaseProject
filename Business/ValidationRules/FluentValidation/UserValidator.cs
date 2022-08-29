using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public  class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("User boş geçilemez.");
            RuleFor(p => p.Email).NotEmpty().WithMessage("Email boş geçilemez.");
            RuleFor(p => p.Email).EmailAddress().WithMessage("Emailinizi formata uygun giriniz.");
            RuleFor(p => p.ImageUrl).NotEmpty().WithMessage("Image URl  boş geçilemez.");
        }
    }
}
