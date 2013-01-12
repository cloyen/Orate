using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orate.Models
{
   public interface IProductDao
    {
        void Add(Product product);

        void Update(Product product);

        void Remove(Product product);

        Product GetById(Double productId);

       // Product GetByName(string name);

       // ICollection<Product> GetByCategory(string category);
    }
}
