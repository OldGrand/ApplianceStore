using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplianceStore.DAL.Interfaces
{
    public interface IRepository<TSource> where TSource : class
    {
        TSource Read(Func<TSource, bool> predicate);
        IQueryable<TSource> ReadAll(Func<TSource, bool> predicate);
        IQueryable<TSource> ReadAll();
        TSource Create(TSource item);
        void Create(IEnumerable<TSource> source);
        void Update(TSource item);
        void Delete(TSource item);
        void DeleteAll();
    }
}
