using System.Collections.Generic;

namespace PSuporte.Domain.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();

        T Get(long id);

        void Delete(long id);

        void Delete(T entity);

        void Update(T entity);

        void Insert(T entity);
    }
}