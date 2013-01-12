using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using orate.Models;
using NHibernate;
using NHibernate.Cfg;

namespace orate.Dao
{
    public class CategoryDao 
    {
        private static CategoryDao instance;
        private static ISessionFactory CategoryDaoSession { get; set; }

        private CategoryDao()
        {
            var configuration = new Configuration();
            configuration.Configure()
            .AddAssembly(typeof(Category).Assembly);
            CategoryDaoSession = configuration.BuildSessionFactory();

        }

        public static CategoryDao GetInstance()
        {
            if (instance == null)
            {
                instance = new CategoryDao();
            }
            return instance;
        }





        public void Add(Category category)
        {
            using (ISession session = CategoryDaoSession.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(category);
                transaction.Commit();
                session.Close();
                session.Dispose();
            }

        }

        public void Update(Category category)
        {
            using (ISession session = CategoryDaoSession.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(category);
                transaction.Commit();
                session.Close();
                session.Dispose();
            }
        }

        public void Remove(Category category)
        {
            using (ISession session = CategoryDaoSession.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(category);
                transaction.Commit();
                session.Close();
                session.Dispose();
            }
        }

      
        public Category GetById(Double categoryId)
        {
            using (ISession session = CategoryDaoSession.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                Category category = session.Get<Category>(categoryId);
                transaction.Commit();
                session.Close();
                session.Dispose();
                return category;


            }
        }

        public Category GetByName(string name)
        {
            
            using(ISession session = CategoryDaoSession.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {

                IQuery query = session.CreateQuery("select c from category c where c.nome=" + name);
                return query.UniqueResult<Category>();
            }
            
        }
        public List<Category> ListAll()
        {
            try
            {
                List<Category> Lista = new List<Category>();
                using (ISession session = CategoryDaoSession.OpenSession())
                {
                    IQuery query = session.CreateQuery("select c from Category c");
                    query.List(Lista);
                    session.Close();
                    session.Dispose();
                }
                return Lista;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

