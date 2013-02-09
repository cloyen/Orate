using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using orate.Models;
namespace orate.Dao
{
    interface ICompanyDao
    {
         void add(Company company);
         void update(Company company);
         void remove(Company company);
         void GetById(Double company);

    }
}
