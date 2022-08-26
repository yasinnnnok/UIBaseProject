using Business.Abstract;
using Core.Utilities.Hashing;
using Entities.Dtos;
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

        public void Register(AuthDto authDto)
        {
            _userService.Add(authDto);
        }
    }
}
