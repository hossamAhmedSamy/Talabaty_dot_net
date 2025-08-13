using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabaty.Core.Entity;
using Talabaty.Core.Repository;

namespace Talabaty.Repository
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _database;   
        public BasketRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();

        }
        public async Task<bool> DeleteBasketAsync(string BasketId)
        {
            return await _database.KeyDeleteAsync(BasketId);    
        }

        public async Task<Customerbasket> GetBasketAsync(string BasketId)
        {
            var Basket= await _database.StringGetAsync(BasketId);
                return Basket.IsNull ? null: JsonSerializer.Deserialize<Customerbasket>(Basket);
        }

        public async Task<Customerbasket> UpdateBasketAsync(Customerbasket basket)
        {
            var jsonBasket = JsonSerializer.Serialize(basket);
            var CreatedOrUpdated = await _database.StringSetAsync(basket.Id.ToString(), jsonBasket, TimeSpan.FromDays(1));
            if (!CreatedOrUpdated)
            {
                return null;
            }
            return await GetBasketAsync(basket.Id.ToString());
        }
    }
}
