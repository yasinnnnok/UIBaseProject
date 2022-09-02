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
        IResult Add(AuthDto authDto);
        IResult Delete(User user);
        IResult Update(User user);
        IResult ChangePassword(UserChangePasswordDto userChangePasswordDto);

        User GetByEmail(string Email);

        IDataResult<List<User>> GetList();
        IDataResult<User> GetById(int id);
        List<OperationClaim> GetUserOperationClaims(int userId);
     


    }
}
