using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using orate.Models;
namespace orate.Dao
{
    interface IoutPutDao
    {
         void add(OutPut outPut);
         void update(OutPut outPut);
         void remove(OutPut outPut);
         OutPut getById(Double id);

    }
}
