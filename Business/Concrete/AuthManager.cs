using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Hashing;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Entities.Dtos;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;

        public AuthManager(IUserService userService)
        {
            _userService= userService;
        }

        public bool Login(LoginAuthDto loginAuthDto)
        {
            var user = _userService.GetByEmail(loginAuthDto.Email);
            if (user!=null)
            {
                var result = HashingHelper.VerifyPasswordHash(loginAuthDto.Password, user.PasswordHash, user.PasswordSalt);

                if (result)
                {
                    return true;
                }
            }           
            
            return false;

        }

        //succcess : true  false
        //message  string
        public IResult Register(AuthDto authDto)
        {
            AuthValidator validationRules = new AuthValidator();
            ValidationResult validationResult = validationRules.Validate(authDto);

          
            if (validationResult.IsValid)
            {
                bool isExist = CheckIfEmailExists(authDto.Email);
                if (isExist)
                {
                    _userService.Add(authDto);
                  
                    return new SuccessResult("Kullanıcı kaydı başarı ile tamamlandı.");
                }
                else
                {           
                    return new ErrorResult("Bu mail adresi daha önce kullanılmış.");

                }
            }

            return new ErrorResult();
            // result.Success = false;
            //return result;

        }

        bool CheckIfEmailExists(string email)
        {
            var list = _userService.GetByEmail(email);
            if (list!=null)
            {
                return false;
            }
            //yoksa true
            return true;
        }



    }
}
