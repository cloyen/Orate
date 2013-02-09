using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using orate.Models;
namespace orate.Dao
{
    interface IitemOutPut
    {
         void add(ItemOutPut Item);
         void update(ItemOutPut Item);
         void remove(ItemOutPut Item);
         ItemOutPut getById(Double Id);

    }

}
