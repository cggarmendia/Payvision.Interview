using Refactoring.FraudDetection.Infrastructure.Cache.Contracts;
using System.Collections.Concurrent;

namespace Refactoring.FraudDetection.Infrastructure.Cache.Implementations
{
    public class CustomCache : ICustomCache
    {
        #region Propeties
        private readonly ConcurrentDictionary<string, object> _cache;
        #endregion

        #region Ctors
        public CustomCache()
        {
            _cache = new ConcurrentDictionary<string, object>();
        }
        #endregion

        #region Public_Methods
        public void TryAdd<T>(string key, T value)
        {
            _cache.TryAdd(key, value);
        }
        public T TryGetValue<T>(string key)
        {
            _cache.TryGetValue(key, out var value);
            return (T)value;
        }
        public bool ContainsKey(string key)
        {
            return _cache.ContainsKey(key);
        }
        #endregion
    }
}
