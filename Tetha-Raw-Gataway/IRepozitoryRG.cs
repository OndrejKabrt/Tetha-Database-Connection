using Tetha_Row_Gataway;

namespace Tetha_Row_Gataway
{
    public interface IRepozitoryRG<T> where T : IBaseClass
    {
        T GetByID(int id);
        void DeleteByID(int id);
        void InsertInto(T element);
        void UpdateByID(T element);

    }
}
