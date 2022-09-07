using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {
        private readonly IOperationClaimDal _operationClaimDal;
    

        //interface i new lemek lazım kullanmak için. Bunu Consructor ile yapıyoruz.
        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
          
        }

        public IResult Add(OperationClaim operationClaim)
        {
            OperationClaimsValidator validationRules = new OperationClaimsValidator();
            ValidationResult result = validationRules.Validate(operationClaim);


            if (result.IsValid)
            {
                bool isExist = GetByOperationClaim(operationClaim.Name);
                if (isExist)
                {
                    _operationClaimDal.Add(operationClaim);
                    return new SuccessResult("Ekleme işlemi başarılı");
                }
                return new ErrorResult("Bu Rol daha önce eklenmiş.");
            }

            return new ErrorResult();
        }

        public void Delete(OperationClaim operationClaim)
        {
            _operationClaimDal.Delete(operationClaim);
        }

        public OperationClaim GetById(int id)
        {
            var result = _operationClaimDal.Get(p => p.Id == id);
            return result;
        }

        public bool GetByOperationClaim(string name)
        {
            var list = _operationClaimDal.Get(p=>p.Name == name);
                      
            if (list!=null)
            {
                return false;
            }
            return true;
        }

        public List<OperationClaim> GetList()
        {
            return _operationClaimDal.GetAll();
        }

        public void Update(OperationClaim operationClaim)
        {
            _operationClaimDal.Update(operationClaim);

        }

        //bool OperationClaimVarmi(string operationClaim)
        //{
        //    var list = GetByOperationClaim(operationClaim);
        //    if (list!=null)
        //    {
        //        return false;
        //    }
        //    return true;
        //}


    }
}
