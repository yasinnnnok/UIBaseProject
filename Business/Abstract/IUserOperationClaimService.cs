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
        void Update(UserOperationClaim userOperationClaim);
        bool GetByUserOperationClaim(int userId, int operationId);


        List<UserDto> GetList();
        UserOperationClaim GetById(int id);
    }
}
