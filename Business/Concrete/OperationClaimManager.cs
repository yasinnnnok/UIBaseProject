using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {
        private readonly IOperationClaimDal _operationClaimDal;

        //interface i new lemek lazım kullanmak için. Bunu Consructor ile yapıyoruz.
        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }

        public void Add(OperationClaim operationClaim)
        {
            _operationClaimDal.Add(operationClaim);
        }

        public void Delete(OperationClaim operationClaim)
        {
           _operationClaimDal.Delete(operationClaim);
        }

        public OperationClaim GetById(int id)
        {
            var result = _operationClaimDal.Get(p=>p.Id == id);
            return result;
        }

        public List<OperationClaim> GetList()
        {
            return _operationClaimDal.GetAll();
        }

        public void Update(OperationClaim operationClaim)
        {
            _operationClaimDal.Update(operationClaim);

        }
    }
}
