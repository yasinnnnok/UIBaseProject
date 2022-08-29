using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public  class OperationClaimsValidator:AbstractValidator<OperationClaim>
    {
        public OperationClaimsValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("User boş geçilemez.");          

           
            RuleFor(x => x.Name).MinimumLength(4).WithMessage("4 karakterden aşağı geçilemez");
        }
    }
}
