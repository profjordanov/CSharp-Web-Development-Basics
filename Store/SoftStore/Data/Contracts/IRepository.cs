using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using SoftStore.Models;

namespace SoftStore.Data.Contracts
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);

        bool Any(Expression<Func<T, bool>> expression);

        int Count();

        T FirstOrDefault(Expression<Func<T, bool>> expression);
        IEnumerable<T> Entities { get; }
        T Find(int id);
        void Remove(int bindId);
    }
}
