using Dominio.Modelo;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data.Nhibernate
{


    public class NHibernateHelper
    {

        public static ISession OpenSession()
        {

            ISessionFactory sessionFactory = Fluently.Configure()
                                                        .Database(
                                                            MySQLConfiguration.Standard.ConnectionString(x => x.FromConnectionStringWithKey
                                                                                                                  ("ConnectionString")
                                                                                                              ))
                                                        .Mappings(
                                                            c => c.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .ExposeConfiguration(cfg => new SchemaExport(cfg)
                                                .Create(false, false))
                .BuildSessionFactory();

            return sessionFactory.OpenSession();
        }
    }
}
