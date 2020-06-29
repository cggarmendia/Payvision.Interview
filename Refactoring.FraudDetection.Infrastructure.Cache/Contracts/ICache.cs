namespace Refactoring.FraudDetection.Infrastructure.Cache.Contracts
{
    public interface ICustomCache
    {
        void TryAdd<T>(string key, T value);
        T TryGetValue<T>(string key);
        bool ContainsKey(string key);
    }
}
