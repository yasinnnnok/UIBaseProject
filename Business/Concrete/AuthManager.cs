using Business.Abstract;
using Business.Contans;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Hashing;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Core.Utilities.Security.JWT;
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
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHandler _tokenHandler;

        public AuthManager(IUserService userService,ITokenHandler tokenHandler)
        {
            _userService= userService;
            _tokenHandler= tokenHandler;
        }

        public bool Login(LoginAuthDto loginAuthDto)
        {
            var user = _userService.GetByEmail(loginAuthDto.Email);
            if (user!=null)
            {
                var result = HashingHelper.VerifyPasswordHash(loginAuthDto.Password, user.PasswordHash, user.PasswordSalt);
                List<OperationClaim> operationClaims = _userService.GetUserOperationClaims(user.Id);
                if (result)
                {
                    Token token = new Token();
                    token = _tokenHandler.CreateToken(user,operationClaims);

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
                  
                    return new SuccessResult(AuthMessages.AddUser);
                }
                else
                {           
                    return new ErrorResult(AuthMessages.WrongMail);

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
