using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabaty.Core.Entity;

namespace Talabaty.Core.Repository
{
    public interface IBasketRepository
    {
        Task<Customerbasket> GetBasketAsync(string BasketId);
        Task<Customerbasket> UpdateBasketAsync(Customerbasket basket);
        Task<bool> DeleteBasketAsync(string BasketId);
    }
}
