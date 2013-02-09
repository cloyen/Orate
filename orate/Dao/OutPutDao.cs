using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using orate.Models;
using NHibernate.Cfg;
using NHibernate;

namespace orate.Dao
{
    public class OutPutDao : IoutPutDao
    {
        private static OutPutDao Instance { get; set; }
        private static ISessionFactory OutPutDaoSession { get; set; }


        private OutPutDao()
        {
            var configuration = new Configuration();
            configuration.Configure().AddAssembly(typeof(OutPut).Assembly);
            OutPutDaoSession = configuration.BuildSessionFactory();
        }

        public static OutPutDao getInstance()
        {
            if (Instance == null)
            {
                Instance = new OutPutDao();
                return Instance;
            }
            else { return Instance; }
        }


        public void add(OutPut outPut)
        {
            using (ISession session = OutPutDaoSession.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(outPut);
                transaction.Commit();
                session.Close();
                session.Dispose();
            }

        }
        public void update(OutPut outPut)
        {
            using (ISession session = OutPutDaoSession.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(outPut);
                transaction.Commit();
                session.Close();
                session.Dispose();
            }
        }
        public void remove(OutPut outPut)
        {
            using (ISession session = OutPutDaoSession.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(outPut);
                transaction.Commit();
                session.Close();
                session.Dispose();
            }
        }
        public OutPut getById(Double id)
        {
            OutPut outPut = new OutPut();
            using (ISession session = OutPutDaoSession.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                outPut = session.Get<OutPut>(id);
                transaction.Commit();
                session.Close();
                session.Dispose();
            }
            return outPut;
        }

        public OutPut getOutPutByDate(DateTime Date)
        {
            OutPut outPut = new OutPut();
            using (ISession session = OutPutDaoSession.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                
                IQuery query = session.CreateQuery("Select o from OutPut o where o.Date=?").SetDateTime(0,Date);
                outPut = query.UniqueResult<OutPut>();
                session.Close();
                session.Dispose();
            }
            return outPut;
        }


        public List<OutPut> getAll()
        {
            List<OutPut> Lista = new List<OutPut>();
            using (ISession session = OutPutDaoSession.OpenSession())            
            {
                IQuery query = session.CreateQuery("Select o from OutPut o");
                query.List(Lista);
                
            }
            return Lista;
        }

    }
}