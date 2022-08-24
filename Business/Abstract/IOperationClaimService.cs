﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOperationClaimService
    {
        void Add(OperationClaim operationClaim);
        void Delete(OperationClaim operationClaim);
        void Update(OperationClaim operationClaim);

        
        List<OperationClaim> GetList();
        OperationClaim GetById(int id);



        
  
    }
}
