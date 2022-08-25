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
    internal class UserOperationClaimManager : IUserOperationClaimService
    {
        //servisten implemente ettik ama Data Acces e bağlanıyoruz.
        private readonly IUserOperationDal _userOperationDal;

        //consructor ile ürettik
        public UserOperationClaimManager(IUserOperationDal userOperationDal)
        {
            _userOperationDal = userOperationDal;
        }

        public void Add(UserOperationClaim userOperationClaim)
        {
            _userOperationDal.Add(userOperationClaim);
        }

        public void Delete(UserOperationClaim userOperationClaim)
        {
            _userOperationDal.Delete(userOperationClaim);
        }

        public UserOperationClaim GetById(int id)
        {
            var result = _userOperationDal.Get(p=>p.Id == id);
            return result;
        }

        public List<UserOperationClaim> GetList()
        {
            return _userOperationDal.GetAll();
        }

        public void Update(UserOperationClaim userOperationClaim)
        {
            _userOperationDal.Update(userOperationClaim);
        }
    }
}
