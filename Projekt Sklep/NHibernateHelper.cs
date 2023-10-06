﻿using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Projekt_Sklep.Models.Klient;
using System.Data.SqlClient;
namespace Projekt_Sklep.Models
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        public static NHibernate.ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    _sessionFactory = Fluently.Configure()
                        .Database(
                            MsSqlConfiguration.MsSql2012.ConnectionString("Server=localhost\\SQLEXPRESS;Database=Test;Integrated Security=SSPI;Application Name=Projekt Sklep;TrustServerCertificate=true;")
                        )
                        .Mappings(m =>
                            m.FluentMappings.AddFromAssemblyOf<KlientEntity>()
                        )
                        .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                        .BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }
    }
}