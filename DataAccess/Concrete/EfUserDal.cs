using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfUserDal : EfEntityRepositoryBase<User, SimpleContextDb>, IUserDal
    {
        public List<OperationClaim> GetUserOperationClaims(int userId)
        {
            using (var context =new  SimpleContextDb())
            {
                var result = from userOperationClaim in context.UserOperationClaims.Where(p => p.UserId == userId)
                             join operationClaim in context.OperationClaims on userOperationClaim.OperationClaimId equals operationClaim.Id
                             select new OperationClaim
                             {
                                 Id = operationClaim.Id,
                                 Name = operationClaim.Name
                             };
                return result.OrderBy(p => p.Name).ToList();
            }
        }
    }
}
