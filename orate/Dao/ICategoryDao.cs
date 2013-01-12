using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using orate.Models;

namespace orate.Dao
{
    interface ICategoryDao
    {
        void Add(Category category);

        void Update(Category category);

        void Remove(Category category);

        Category GetById(Double categoryId);

        //Category GetByName(string name);

        

    }
}
