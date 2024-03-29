﻿using MutluGunlerFirini.Business.Abstract;
using MutluGunlerFirini.Business.Constants;
using MutluGunlerFirini.Core.Utilities.Results;
using MutluGunlerFirini.DataAccess.Abstract;
using MutluGunlerFirini.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutluGunlerFirini.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        private List<User> _users = new List<User>
        {
            new User { FirstName = "Test", LastName = "User", Email = "test", Password = "test" } ,
            new User { FirstName = "Test", LastName = "User", Email = "celil@gmail.com", Password = "1980" }
        };

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<User> Login(string email, string password)
        {
            return new SuccessDataResult<User>(_userDal.GetList(u => u.Email == email && u.Password == password).FirstOrDefault());
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public async Task<User> Authenticate(string username, string password)
        {
            var user = await Task.Run(() => _users.SingleOrDefault(x => x.Email == username && x.Password == password));

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so return user details without password
            user.Password = null;
            return user;
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId));
        }

        public IDataResult<List<User>> GetList()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetList());
        }


        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
