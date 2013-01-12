using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace orate.Models
{
    public class Product
    {
        public virtual double Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Category Category { get; set; }
        public virtual string Discontinued { get; set; }
        public virtual double Quantity { get; set; }
    }
}

