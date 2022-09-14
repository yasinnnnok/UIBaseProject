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
    public  interface IUserOperationClaimService
    {
        IResult Add(UserDto userDto);
       
        void Delete(UserOperationClaim userOperationClaim);
        IResult Update(UserDto userDto);
        IResult GetByUserOperationClaim(User user, OperationClaim operationClaim);
        IResult GetByUser(User user);
        IResult GetByOperationClaim(OperationClaim operationClaim);


        List<UserDto> GetList();
        UserOperationClaim GetById(int id);
    }
}
