using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabaty.Core.Entity;
using Talabaty.Core.specifcation;

namespace Talabaty.Repository
{
    public class SpecificationEvalutor<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery , Ispecification<T> spec)
        {
            var query = inputQuery;
            if(spec.Criteria is not  null)
            {
                query = query.Where(spec.Criteria);
            }
            query = spec.Includes.Aggregate(query, (CurrentQuery, IncludeExpression) => CurrentQuery.Include(IncludeExpression));
            
            return query;

        }

        internal static async Task<IEnumerable<T>> GetQuery<T>(Func<DbSet<T>> set, Ispecification<T> spec) where T : BaseEntity
        {
            throw new NotImplementedException();
        }
    }
}
