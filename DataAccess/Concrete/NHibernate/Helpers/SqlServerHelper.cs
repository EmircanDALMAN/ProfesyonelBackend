using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using Shared.DataAccess.NHibernate;

namespace Northwind.DataAccess.Concrete.NHibernate.Helpers
{
    public class SqlServerHelper : NHibernateHelper
    {
        protected override ISessionFactory InitializeFactory()
        {
            const string connectionString = @"server=(localdb)\mssqllocaldb;Database=Northwind;Integrated Security=true";
            return Fluently.Configure().Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString(connectionString))
                .Mappings(t => t.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory();
        }
    }
}
