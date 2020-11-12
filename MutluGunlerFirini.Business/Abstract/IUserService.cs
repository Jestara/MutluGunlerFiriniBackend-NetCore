using MutluGunlerFirini.Core.Utilities.Results;
using MutluGunlerFirini.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MutluGunlerFirini.Business.Abstract
{
    public interface IUserService
    {
        IDataResult<User> Login(string email, string password);
        IDataResult<User> GetById(int userId);
        IDataResult<List<User>> GetList();
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
        Task<User> Authenticate(string username, string password);
    }
}
