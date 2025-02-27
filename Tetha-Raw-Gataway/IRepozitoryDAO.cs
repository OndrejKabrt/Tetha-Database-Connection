﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetha_Row_Gataway
{
    //Vytvoříme si dědičné metody potřebné ke komunikaci s databází
    public interface IRepozitoryDAO<T> where T : IBaseClass
    {
        T GetByID(int id);
        IEnumerable<T> GetAll();
        void Save(T element);
        void Delete(T element);
    }
}
