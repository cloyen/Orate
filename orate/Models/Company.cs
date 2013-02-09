using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace orate.Models
{
    public class Company
    {
        public virtual double Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<OutPut> Outputs { get; set; }
    }
}