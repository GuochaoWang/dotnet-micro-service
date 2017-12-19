using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceStructure.Service.Product.API.Model
{
    public class RedisProductRepository : IProductRepository
    {
        private readonly ILogger<RedisProductRepository> _logger;

        private readonly ConnectionMultiplexer _redis;
        private readonly IDatabase _database;

        public RedisProductRepository(ILoggerFactory loggerFactory, ConnectionMultiplexer redis)
        {
            _logger = loggerFactory.CreateLogger<RedisProductRepository>();
            _redis = redis;
            _database = redis.GetDatabase();
        }

        public async Task<bool> DeleteProductAsync(string id)
        {
            return await _database.KeyDeleteAsync(id);
        }

        public async Task<Product> GetProductAsync(string id)
        {
            var data = await _database.StringGetAsync(id);
            if (data.IsNullOrEmpty)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<Product>(data);
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            var created = await _database.StringSetAsync(product.Id, JsonConvert.SerializeObject(product));
            if (!created)
            {
                _logger.LogInformation("Problem occur persisting the item.");
                return null;
            }

            _logger.LogInformation("Basket item persisted succesfully.");

            return product;
        }
    }
}
