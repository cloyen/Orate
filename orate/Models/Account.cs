using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using orate.Dao;

namespace orate.Models
{
    public class Account
    {
        public virtual Double Id { get; set; }
        public virtual string Nick { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual string Type { get; set; }

    }
}