using System.Collections.Generic;
using MSCars.Model.Base;

namespace MSCars.Business.Interfaces
{
    public interface IBaseService<T> where T : BaseEntity
    {
        void Add(T entity);

        void Remove(int entityId);

        void Update(T entity);

        IEnumerable<T> GetAll();

        T Get(int entityId);
    }
}
