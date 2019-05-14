using System;
using System.Collections.Generic;

namespace DataAccess
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        List<T> FindById(int id);
        bool Add(T entity);
        bool Delete(T entity);
        bool Edit(T entity);
    }
}
