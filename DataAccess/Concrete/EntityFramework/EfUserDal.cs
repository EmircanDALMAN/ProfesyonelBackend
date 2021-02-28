using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.ComplexTypes;
using Entities.Concrete;
using Shared.DataAccess.EntityFramework;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User,NorthwindContext>, IUserDal
    {
        public List<UserRoleDetails> GetRoles(User user)
        {
            using var context = new NorthwindContext();
            var result = from ur in context.UserRoles
                join r in context.Roles on ur.UserId equals user.Id
                where ur.UserId == user.Id
                select new UserRoleDetails
                {
                    RoleName = r.Name
                };
            return result.ToList();
        }
    }
}
