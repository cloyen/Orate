using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using orate.Models;
using NHibernate;
using NHibernate.Cfg;
using NUnit.Framework;

namespace orate.Dao
{
    public class ProductDao
    {
        private static ProductDao instance { get; set; }
        private static ISessionFactory ProductDaoSession { get; set; }

        private ProductDao()
        {
            var configuration = new Configuration();
            configuration.Configure()
            .AddAssembly(typeof(Product).Assembly);
            ProductDaoSession = configuration.BuildSessionFactory();

        }

        public static ProductDao GetInstance()
        {
            if (instance == null)
            {
                instance = new ProductDao();
                return instance;
            }
            else
            {
                ProductDao aux = instance;
                return aux;
            }
        }



        public void Add(Product product)
        {
            using (ISession session = ProductDaoSession.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(product);
                transaction.Commit();
                session.Close();
                session.Dispose();
            }
        }

        public void Update(Product product)
        {
            using (ISession session = ProductDaoSession.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(product);
                transaction.Commit();
                session.Close();
                session.Dispose();
            }
        }

        public void Remove(Product product)
        {
            using (ISession session = ProductDaoSession.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(product);
                transaction.Commit();
                session.Close();
                session.Dispose();

            }
        }

        public Product GetById(Double productId)
        {
            using (ISession session = ProductDaoSession.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                Product product = session.Get<Product>(productId);
                transaction.Commit();
                session.Close();
                session.Dispose();
                return product;
            }
        }

        public IList<Product> GetByName(string name)
        {
            try
            {
                List<Product> Lista = new List<Product>();
                using (ISession session = ProductDaoSession.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    IQuery query = session.CreateQuery("Select p.* from Product p where p.id=" + name);
                    query.List(Lista);
                    return Lista;
                    session.Close();
                    session.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ICollection<Product> GetByCategory(Double categoryId)
        {
            try
            {
                List<Product> Lista = new List<Product>();
                using (ISession session = ProductDaoSession.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    IQuery query = session.CreateQuery("Select p.* from Product p where p.id=" + categoryId);
                    query.List(Lista);
                    return Lista;
                   
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public List<Product> ListAll()
        {
            try
            {
                List<Product> Lista = new List<Product>();
                using (ISession session = ProductDaoSession.OpenSession())
                {
                    IQuery query = session.CreateQuery("select p from Product p");
                    query.List(Lista); 
                    
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
