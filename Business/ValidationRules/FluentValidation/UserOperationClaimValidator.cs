using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public  class UserOperationClaimValidator:AbstractValidator<UserOperationClaim>
    {
        public UserOperationClaimValidator()
        {
            RuleFor(p => p.UserId).NotEmpty().WithMessage("User boş geçilemez.");
            RuleFor(p => p.OperationClaimId).NotEmpty().WithMessage("Operation Claim boş geçilemez.");
        }
    }
}
