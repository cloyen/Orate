using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace orate.Models
{
    public class ItemOutPut
    {
        public virtual double Id { get; set; }
        public virtual OutPut OutPut { get; set; }
        public virtual Product Product { get; set; }
        public virtual double Quantity { get; set; }

    }
}