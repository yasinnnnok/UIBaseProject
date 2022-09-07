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
        IResult Add(UserOperationClaim userOperationClaim);
        void Delete(UserOperationClaim userOperationClaim);
        void Update(UserOperationClaim userOperationClaim);


        List<UserDto> GetList();
        UserOperationClaim GetById(int id);
    }
}
