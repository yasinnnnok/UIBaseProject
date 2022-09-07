using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOperationClaimService
    {
        IResult Add(OperationClaim operationClaim);
        void Delete(OperationClaim operationClaim);
        void Update(OperationClaim operationClaim);

        bool GetByOperationClaim(string operationClaim);
        List<OperationClaim> GetList();
        OperationClaim GetById(int id);



        
  
    }
}
