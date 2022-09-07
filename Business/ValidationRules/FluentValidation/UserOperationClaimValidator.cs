using Entities.Concrete;
using Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public  class UserOperationClaimValidator:AbstractValidator<UserDto>
    {
        public UserOperationClaimValidator()
        {
            RuleFor(p => p.KullaniciAdi).NotEmpty().WithMessage("User boş geçilemez.");
            RuleFor(p => p.OperasyonAdi).NotEmpty().WithMessage("Operation Claim boş geçilemez.");
        }
    }
}
