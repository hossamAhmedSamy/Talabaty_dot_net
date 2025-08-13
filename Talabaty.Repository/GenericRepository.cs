using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Talabaty.Core.Entity;
using Talabaty.Core.Repository;
using Talabaty.Core.specifcation;
using Talabaty.Repository.Data;

namespace Talabaty.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _dbContext;

        public GenericRepository(StoreContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public GenericRepository() { }

        public Task AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            if(typeof(T)== typeof(Product))
            {
                return (IEnumerable<T>)await _dbContext.Products
                    .Include(p => p.ProductBrand)
                    .Include(p => p.ProductType)
                    .ToListAsync();
            }
            else
            {
                return await _dbContext.Set<T>().ToListAsync();
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id) 
                   ?? throw new KeyNotFoundException($"Entity of type {typeof(T).Name} with ID {id} not found.");

        }

        public Task UpdateAsync(T entity)
        {
             throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllWithSpecAsync(Ispecification<T> Spec)
        {
            return await ApplySpecification(Spec).ToListAsync();

        }

        public async Task<T> GetByIdWithSpecAsync(Ispecification<T> Spec)
        {
            return await ApplySpecification(Spec).FirstOrDefaultAsync();

        }
        private IQueryable<T> ApplySpecification(Ispecification<T> Spec)
        {
            return SpecificationEvalutor<T>.GetQuery(_dbContext.Set<T>(), Spec);
        }

        public async Task<int> GetCountWithSpecAsync(Ispecification<T> Spec)
        {
            return await ApplySpecification(Spec).CountAsync();
        }
    }
}
