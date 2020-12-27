using ApplianceStore.DAL.Entities;
using ApplianceStore.DAL.Interfaces;
using ApplianceStore.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace ApplianceStore.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _db;

        private IRepository<Product> _productRepository;
        private IRepository<Sale> _saleRepository;
        private IRepository<Supply> _supplyRepository;

        public IRepository<Product> ProductRepository => _productRepository ??= new Repository<Product>(_db);
        public IRepository<Sale> SaleRepository => _saleRepository ??= new Repository<Sale>(_db);
        public IRepository<Supply> SupplyRepository => _supplyRepository ??= new Repository<Supply>(_db);

        public UnitOfWork(DbContext dbContext)
        {
            _db = dbContext;
        }

        private bool disposed = false;
       
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
