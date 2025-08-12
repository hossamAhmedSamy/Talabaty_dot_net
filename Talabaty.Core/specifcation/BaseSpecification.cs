using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabaty.Core.Entity;

namespace Talabaty.Core.specifcation
{
    public class BaseSpecification<T> : Ispecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Criteria { get ; set ; }
        public List<Expression<Func<T, object>>> Includes { get ; set ; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrderBy { get; set; }
        public Expression<Func<T, object>> OrderByDesc { get; set; }

        public BaseSpecification()
        {
            
        }
        public BaseSpecification(Expression<Func<T, bool>> CriteriaExpression) 
        {
            Criteria = CriteriaExpression;
            
        }
        public void AddOrderBy(Expression<Func<T,object>> orderByExpression)
        {
            OrderBy = orderByExpression;

        }
        public void AddOrderByDesc(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDesc = orderByDescExpression;

        }
    }
}
