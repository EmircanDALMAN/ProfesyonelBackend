using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete.Managers;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Ninject.Modules;
using Northwind.DataAccess.Concrete.NHibernate.Helpers;
using Shared.DataAccess;
using Shared.DataAccess.EntityFramework;
using Shared.DataAccess.NHibernate;

namespace Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();


            Bind<IUserService>().To<UserManager>().InSingletonScope();
            Bind<IUserDal>().To<EfUserDal>().InSingletonScope();

            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>));
            Bind<DbContext>().To<NorthwindContext>();
            Bind<NHibernateHelper>().To<SqlServerHelper>();
        }
    }
}
