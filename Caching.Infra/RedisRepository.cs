using Caching.Domain;
using Caching.Infra.Interfaces;
using StackExchange.Redis;
using System.Text.Json;

namespace Caching.Infra
{
    public class RedisRepository<T> : IRedisRepository<T>
    {
        private readonly IDatabase _database;

        public RedisRepository(IDatabase redisDatabase)
        {
            _database = redisDatabase;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {

            var keys = await _database.ExecuteAsync("KEYS", "*");
            if (keys.Length > 0)
            {
                var items = new List<T>();
                foreach (var key in (RedisResult[])keys)
                {
                    var item = await _database.StringGetAsync((string)key);
                    items.Add(Serialize<T>(item));
                }
                return items;
            }
            else
            {
                return null;
            }

        }

        public async Task<T> GetByIdAsync(string id)
        {
            var item = await _database.StringGetAsync(id);
            return Serialize<T>(item);
        }

        public async Task DeleteAsync(string id)
        {
            await _database.KeyDeleteAsync(id);
        }

        public async Task SetAsync(string id, T entity)
        {
            await _database.StringSetAsync(id, Serialize(entity));
        }
        private T Serialize<T>(RedisValue value)
        {
            if (!value.IsNull)
                return JsonSerializer.Deserialize<T>(value);
            else
                return default;
        }

        private RedisValue Serialize<T>(T obj)
        {

            return JsonSerializer.Serialize(obj);
        }

        public async Task SetAllAsync(IEnumerable<TaskItem> entities)
        {
            var redisValues = new Dictionary<RedisKey, RedisValue>();
            foreach (var entity in entities)
            {
                var key = $"Entity:{entity.Id}";
                var serializedEntity = Serialize(entity);
                redisValues.Add(key, serializedEntity);
            }

            await _database.StringSetAsync(redisValues.ToArray());
        }
    }
}