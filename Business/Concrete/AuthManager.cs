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
using Core.Utilities.Business;
namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHandler _tokenHandler;

        public AuthManager(IUserService userService, ITokenHandler tokenHandler)
        {
            _userService = userService;
            _tokenHandler = tokenHandler;
        }

        public IDataResult<Token> Login(LoginAuthDto loginAuthDto)
        {
            var user = _userService.GetByEmail(loginAuthDto.Email);
            if (user != null)
            {
                var result = HashingHelper.VerifyPasswordHash(loginAuthDto.Password, user.PasswordHash, user.PasswordSalt);
                List<OperationClaim> operationClaims = _userService.GetUserOperationClaims(user.Id);
                if (result)
                {
                    Token token = new Token();
                    token = _tokenHandler.CreateToken(user, operationClaims);
                    return new SuccessDataResult<Token>(token);
                }
                return new ErrorDataResult<Token>(AuthMessages.WrongPassword);
            }
            return new ErrorDataResult<Token>(AuthMessages.WrongNotMail);
        }
        //succcess : true  false
        //message  string
        public IResult Register(AuthDto authDto)
        {
            int imgSize = 1;

            AuthValidator validationRules = new AuthValidator();
            ValidationResult validationResult = validationRules.Validate(authDto);

            if (validationResult.IsValid)
            {
                IResult result = BusinessRules.Run(
                     CheckIfEmailExists(authDto.Email),
                      esimBirMbKucukmu(imgSize)
                    );

                if (!result.Success)
                {
                    return result;
                }
                _userService.Add(authDto);
                return new SuccessResult(AuthMessages.AddUser);
            }
            return new ErrorResult();

        }

        private IResult CheckIfEmailExists(string email)
        {
            var list = _userService.GetByEmail(email);
            if (list != null)
            {
                return new ErrorResult(AuthMessages.WrongExistMail);
            }
            //yoksa true
            return new SuccessResult();
        }

        private IResult esimBirMbKucukmu(int imgSize)
        {
            if (imgSize > 1)
            {
                return new ErrorResult(AuthMessages.WrongImageSize);
            }
            //Küçükse true
            return new SuccessResult();
        }



    }
}
