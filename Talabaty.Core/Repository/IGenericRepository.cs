using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabaty.Core.Entity;
using Talabaty.Core.specifcation;

namespace Talabaty.Core.Repository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);


        Task<IEnumerable<T>> GetAllWithSpecAsync(Ispecification<T> Spec);
        Task<T> GetByIdWithSpecAsync(Ispecification<T> Spec);
    }
}
