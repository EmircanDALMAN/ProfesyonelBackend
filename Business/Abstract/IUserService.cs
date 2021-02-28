using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.ComplexTypes;
using Entities.Concrete;
using Shared.Utilities.Results;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<User> GetByUserNameAndPassword(string userName, string password);
        IDataResult<List<UserRoleDetails> > GetUserRoles(User user);
    }
}
