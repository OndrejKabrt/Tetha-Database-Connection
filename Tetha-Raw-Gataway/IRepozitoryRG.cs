using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TethaRawGataway;

namespace Tetha_Raw_Gataway
{
    public interface IRepozitoryRG<T> where T : IBaseClass
    {
        T GetByID(int id);

        void DeleteByID(T element);
        void InsertInto(T element);
        void UpdateByID(T element);

    }
}
