using Business.Abstract;
using Business.Contans;
using Core.Utilities.Hashing;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
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
        private readonly IUserOperationClaimService _userOperationClaimService;
        private readonly IFileService _fileService;

        //consructor ile ürettik
        public UserManager(IUserDal userDal,IFileService fileService, IUserOperationClaimService userOperationClaimService)
        {
            _userDal = userDal;
            _fileService = fileService;
            _userOperationClaimService = userOperationClaimService;
        }


        public IResult Add(AuthDto authDto)
        {
           string fileName = _fileService.FileSave(authDto.Image,"wwwroot/image/");
            fileName = "/image/" + fileName;
           var user = CreateUser(authDto,fileName);
           
            _userDal.Add(user);
            return new SuccessResult();
        }

        private User CreateUser(AuthDto authDto,string fileName)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePassword(authDto.Password, out passwordHash, out passwordSalt);

            User user = new User();
            user.Id = 0;
            user.Email = authDto.Email;
            user.Name = authDto.Name;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.ImageUrl = fileName;
            return user;

        }


        public IResult ChangePassword(UserChangePasswordDto userChangePasswordDto)
        {
            var user = _userDal.Get(p => p.Id == userChangePasswordDto.UserId);
            bool result = HashingHelper.VerifyPasswordHash(userChangePasswordDto.CurrentPassword, user.PasswordHash, user.PasswordSalt);
            if (!result)
            {
                return new ErrorResult(UserMessages.CurrentWrongPassword);
            }


            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePassword(userChangePasswordDto.NewPassword, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            _userDal.Update(user);
            return new SuccessResult(UserMessages.ChangePassword);
        }

        public IResult Delete(User user)
        {
            var result = _userOperationClaimService.GetByUser(user);
            if (result.Success)
            {
                _userDal.Delete(user);
                return new SuccessResult(UserMessages.DeletedUser);

            }
            return new ErrorResult(UserMessages.WrongDeletedUser);

        }


        public User GetByEmail(string email)
        {
            var result = _userDal.Get(p => p.Email == email);
            return result;
        }

        public IDataResult<User> GetById(int id)
        {
            var result = _userDal.Get(p => p.Id == id);
            return new SuccessDataResult<User>(result);
        }



        public IDataResult<List<User>> GetList()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(UserMessages.UpdatedUser);
        }

        public List<OperationClaim> GetUserOperationClaims(int userId)
        {
            return _userDal.GetUserOperationClaims(userId);
        }
    }
}
