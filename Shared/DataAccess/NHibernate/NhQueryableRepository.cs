using System.Linq;
using Shared.Entities;

namespace Shared.DataAccess.NHibernate
{
    public class NhQueryableRepository<T>:IQueryableRepository<T> where T:class,IEntity,new()
    {
        private readonly NHibernateHelper _nHibernateHelper;
        private IQueryable<T> _entities;

        public NhQueryableRepository(NHibernateHelper nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }

        public IQueryable<T> Table => Entities;

        public virtual IQueryable<T> Entities
        {
            get { return _entities ??= _nHibernateHelper.OpenSession().Query<T>(); }
        }
    }
}
