using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using orate.Models;
using NHibernate;
using NHibernate.Cfg;

namespace orate.Dao
{
    public class CompanyDao 
    {
        private static CompanyDao instance { get; set; }
        private static ISessionFactory CompanyDaoSession { get; set; }

        private CompanyDao()
        {
            var configuration = new Configuration();
            configuration.Configure().AddAssembly(typeof(Company).Assembly);
            CompanyDaoSession = configuration.BuildSessionFactory();
        }

        public static CompanyDao getInstance()
        {
            if (instance == null)
            {
                instance = new CompanyDao();
                return instance;
            }
            else
            {
                return instance;
            }
        }

        public void add(Company company)
        {
            using (ISession session = CompanyDaoSession.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(company);
                transaction.Commit();
                session.Close();
                session.Dispose();

            }
        }
        /*
        public void update(Company company);
        public void remove(Company company);*/

        public Company getById(Double Id)
        {
            using (ISession session = CompanyDaoSession.OpenSession())
            {
                Company company = session.Get<Company>(Id);

                return company;

            }
        }
        public List<Company> getAll()
        {
            List<Company> companies = new List<Company>();
            using (ISession session = CompanyDaoSession.OpenSession())
            {
                IQuery query = session.CreateQuery("select c from Company c");
                query.List(companies);
                return companies;

            }

        }
    }
}