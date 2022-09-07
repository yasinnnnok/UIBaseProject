using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    internal class UserOperationClaimManager : IUserOperationClaimService
    {
        //servisten implemente ettik ama Data Acces e bağlanıyoruz.
        private readonly IUserOperationDal _userOperationDal;
        private readonly IUserDal _userDal;
        private readonly IOperationClaimDal _operationClaimDal;

        //consructor ile ürettik
        public UserOperationClaimManager(IUserOperationDal userOperationDal,IUserDal userDal, IOperationClaimDal operationClaimDal)
        {
            _userOperationDal = userOperationDal;
            _userDal= userDal;
            _operationClaimDal = operationClaimDal;
        }

        public IResult Add(UserOperationClaim userOperationClaim)
        {
            UserOperationClaimValidator validationRules = new UserOperationClaimValidator();
            ValidationResult result = validationRules.Validate(userOperationClaim);

            if (result.IsValid)
            {
                _userOperationDal.Add(userOperationClaim);
                return new SuccessResult("Ekleme işlemi başarılı...");
            }

            return new ErrorResult("Ekleme işlemi başarısız...");

        }

        public void Delete(UserOperationClaim userOperationClaim)
        {
            _userOperationDal.Delete(userOperationClaim);
        }

        public UserOperationClaim GetById(int id)
        {
            var result = _userOperationDal.Get(p=>p.Id == id);
            return result;
        }

        public List<UserDto> GetList()
        {

            var userOperationAll = _userOperationDal.GetAll();
            
            List<UserDto> result = new List<UserDto>();
            foreach (var item in userOperationAll)
            {
                var user = _userDal.Get(x => x.Id == item.UserId);
                var opertaion = _operationClaimDal.Get(x => x.Id == item.OperationClaimId);
                var userDto = new UserDto();

                userDto.Id = item.Id;
                userDto.UserId = item.Id;
                userDto.OperationClaimId = item.OperationClaimId;
                userDto.KullaniciAdi = user.Name;
                userDto.OperasyonAdi = opertaion.Name;
                result.Add(userDto);//Bi bak
            }
            
            return result;
        }

        public void Update(UserOperationClaim userOperationClaim)
        {
            _userOperationDal.Update(userOperationClaim);
        }
    }
}
