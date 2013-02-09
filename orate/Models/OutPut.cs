using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace orate.Models
{
    public class OutPut
    {
        public virtual double Id { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual Company Company { get; set; }
        public virtual IList<ItemOutPut> ItemOutPut { get; set; }
    }
}