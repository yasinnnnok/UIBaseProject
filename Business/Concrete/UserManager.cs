using Business.Abstract;
using Core.Utilities.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        //servisten implemente ettik ama Data Acces e bağlanıyoruz.
        private readonly IUserDal _userDal;
        //consructor ile ürettik
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }


        public void Add(AuthDto authDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePassword(authDto.Password,out passwordHash,out passwordSalt);

            User user = new User();
            user.Id = 0;
            user.Email = authDto.Email;
            user.Name = authDto.Name;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.ImageUrl=authDto.ImageUrl;

            _userDal.Add(user);
        }

        public void Delete(User user)
        {
            _userDal.Delete(user);
        }

        public User GetById(int id)
        {
            var result = _userDal.Get(p => p.Id == id);
            return result;
        }

        public List<User> GetList()
        {
            return _userDal.GetAll();
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }
    }
}
