using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Interfaces
{
    /// <summary>
    /// 
    /// 1. Get’s the entity By Id
    /// 2. Get’s all the Record
    /// 3. Finds a set of record that matches the passed expression
    /// 4. Adds a new record to the context
    /// 5. Add a list of records
    /// 6. Removes a record from the context
    /// 7. Removes a list of records.
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
