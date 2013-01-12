using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using orate.Models;
using NHibernate;
using NHibernate.Cfg;
namespace orate.Dao
{
    public class AccountDao
    {
        private static AccountDao instance { get; set; }
        private static ISessionFactory AccountDaoSession { get; set; }

        private AccountDao()
        {
            var configuration = new Configuration();
            configuration.Configure().AddAssembly(typeof(Account).Assembly);
            AccountDaoSession = configuration.BuildSessionFactory();

        }

        public static AccountDao GetInstance()
        {
            if (instance == null)
            {
                instance = new AccountDao();

            }
            return instance;
        }


        public void Add(Account account)
        {
            using (ISession session = AccountDaoSession.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(account);
                transaction.Commit();
                session.Close();
                session.Dispose();
            }

        }

        public void Update(Account account)
        {
            using (ISession session = AccountDaoSession.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(account);
                transaction.Commit();
                session.Close();
                session.Dispose();
            }
        }

        public void Remove(Account account)
        {
            using (ISession session = AccountDaoSession.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(account);
                transaction.Commit();
                session.Close();
                session.Dispose();
            }
        }


        public Account GetById(Double accountId)
        {
            using (ISession session = AccountDaoSession.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                Account account = session.Get<Account>(accountId);
                transaction.Commit();
                session.Close();
                session.Dispose();
                return account;


            }
        }

        public List<Account> GetByName(string name)
        {
            List<Account> Lista = new List<Account>();
            using (ISession session = AccountDaoSession.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {

                IQuery query = session.CreateQuery("select a from Account a where a.nick=" + name);
                query.List(Lista);
            }
            return Lista;
        }
        public Account GetByAccount(string Nick, string Password)
        {
            Account account = new Account();
            // List<Account> Lista = new List<Account>();
            using (ISession session = AccountDaoSession.OpenSession())
            {
                String queryString = "select a from Account a where a.Nick =? and a.Password = ?";
                IQuery query = session.CreateQuery(queryString).SetString(0,Nick).SetString(1,Password);
                account = query.UniqueResult<Account>();
                // query.List(Lista);

            }
            return account;
        }



    }
}