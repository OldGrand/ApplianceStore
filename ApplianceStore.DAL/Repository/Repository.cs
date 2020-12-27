using ApplianceStore.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplianceStore.DAL.Repositories
{
    public class Repository<TSource> : IRepository<TSource> where TSource : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TSource> _set;

        public Repository(DbContext context) => (_context, _set) = (context, context.Set<TSource>());
        
        public TSource Create(TSource item)
        {
            _set.Add(item);
            return item;
        }

        public void Create(IEnumerable<TSource> source) 
        {
            _set.AddRange(source);
        } 

        public void Delete(TSource item)
        {
            _set.Remove(item);
        }

        public void DeleteAll()
        {
            _set.RemoveRange(ReadAll());
        }

        public TSource Read(Func<TSource, bool> predicate)
        {
            return _set.FirstOrDefault(predicate);
        }

        public IQueryable<TSource> ReadAll(Func<TSource, bool> predicate)
        {
            return _set.Where(predicate).AsQueryable();
        }

        public IQueryable<TSource> ReadAll()
        {
            return _set.AsQueryable();
        }

        public void Update(TSource item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
