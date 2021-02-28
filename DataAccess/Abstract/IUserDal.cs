using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.ComplexTypes;
using Entities.Concrete;
using Shared.DataAccess;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<UserRoleDetails> GetRoles(User user);
    }
}
