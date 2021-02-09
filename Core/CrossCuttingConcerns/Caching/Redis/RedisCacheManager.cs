using System;
using Core.Utilities.IoC;
using Core.Utilities.Serialize;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceStack.Redis;
using Core.Settings;
using Core.Settings.RedisSettings;

namespace Core.CrossCuttingConcerns.Caching.Redis
{
    public class RedisCacheManager : ICacheManager
    {
        private readonly RedisEndpoint _redisEndpoint;

        private readonly IDistributedCache _distributedCache;

        private void RedisInvoker(Action<RedisClient> redisAction)
        {
            if (_redisEndpoint == null)
            {
                throw new NullReferenceException();
            }

            using (var client = new RedisClient(_redisEndpoint))
            {
                redisAction.Invoke(client);
            }
        }

        public RedisCacheManager(IRedisSettings redisSettings)
        {
            _distributedCache = ServiceTool.ServiceProvider.GetService<IDistributedCache>();
            _redisEndpoint = new RedisEndpoint(redisSettings.RedisHostIP, Convert.ToInt32(redisSettings.RedisPort));
        }

        public T Get<T>(string key)
        {
            byte[] result;
            result = _distributedCache.Get(key);
            var deserializeResult = CacheSerializer.Deserialize<T>(result);
            return deserializeResult;
        }

        public object Get(string key)
        {
            byte[] result;
            result = _distributedCache.Get(key);
            var deserializeResult = CacheSerializer.Deserialize<object>(result);
            return deserializeResult;
        }

        public void Add(string key, object data, int duration)
        {
            _distributedCache.Set(key, CacheSerializer.Serialize(data), new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(duration)
            });
        }

        public bool IsAdd(string key)
        {
            var isAdded = false;
            RedisInvoker(x => isAdded = x.ContainsKey(key));
            return isAdded;
        }

        public void Remove(string key)
        {
            _distributedCache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var result = default(object);
            RedisInvoker(x => x.RemoveByPattern(pattern));
            result = pattern;
        }

        public void Clear()
        {
            RedisInvoker(x => x.FlushAll());
        }
    }

}
