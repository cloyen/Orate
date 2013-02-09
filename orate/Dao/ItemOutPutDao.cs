using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using orate.Models;
using NHibernate;
using NHibernate.Cfg;
namespace orate.Dao
{
    public class ItemOutPutDao : IitemOutPut
    {
        private static ItemOutPutDao instance { get; set; }
        private static ISessionFactory itemOutPutDaoSession { get; set; }


        private ItemOutPutDao()
        {
            var configuration = new Configuration();
            configuration.Configure().AddAssembly(typeof(ItemOutPut).Assembly);
            itemOutPutDaoSession = configuration.BuildSessionFactory();
        }

        public static ItemOutPutDao getInstance()
        {
            if (instance == null)
            {
                instance = new ItemOutPutDao();
                return instance;
            }
            else
            {
                return instance;
            }
        }

        public void add(ItemOutPut item)
        {
            using (ISession session = itemOutPutDaoSession.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(item);
                transaction.Commit();
                session.Close();
                session.Dispose();

            }

        }
        public void update(ItemOutPut item)
        {
            using (ISession session = itemOutPutDaoSession.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(item);
                transaction.Commit();
                session.Close();
                session.Dispose();

            }

        }
        public void remove(ItemOutPut Item)
        {
            using (ISession session = itemOutPutDaoSession.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(Item);
                transaction.Commit();
                session.Close();
                session.Dispose();
            }
        }
        public ItemOutPut getById(Double id)
        {
            using (ISession session = itemOutPutDaoSession.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                return session.Get<ItemOutPut>(id);
                transaction.Commit();
                session.Close();
                session.Dispose();
            }
            
        }

        public List<ItemOutPut>getAll()
        {
            List<ItemOutPut> lista = new List<ItemOutPut>();
            using(ISession session = itemOutPutDaoSession.OpenSession())
            using(ITransaction transaction = session.BeginTransaction()){

                IQuery query = session.CreateQuery("Select i ITEMOUTPUT i");
                query.List(lista);
                session.Close();
                session.Dispose();

            }

            return lista;
        }

    }
}