using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.ComplexTypes;
using Entities.Concrete;
using Shared.Utilities.Results;

namespace Business.Concrete.Managers
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<User> GetByUserNameAndPassword(string userName, string password)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserName == userName && u.Password == password));
        }

        public IDataResult<List<UserRoleDetails>> GetUserRoles(User user)
        {
            return new SuccessDataResult<List<UserRoleDetails>>(_userDal.GetRoles(user));
        }
    }
}
