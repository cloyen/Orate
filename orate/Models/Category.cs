using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using orate.Dao;


namespace orate.Models
{
    public class Category
    {
        #region Atributes

        public virtual double Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Product> Products { get; set; }

        #endregion
    }
}