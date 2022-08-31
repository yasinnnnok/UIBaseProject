using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public  interface IUserService
    {
        void Add(AuthDto authDto);
        void Delete(User user);
        void Update(User user);
        IResult ChangePassword(UserChangePasswordDto userChangePasswordDto);

        User GetByEmail(string Email);

        List<User> GetList();
        User GetById(int id);
     


    }
}
