using Refactoring.FraudDetection.Infrastructure.Cache.Contracts;
using Refactoring.FraudDetection.Specification.Contracts;
using Refactoring.FraudDetection.Specification.Contracts.Factory;
using Refactoring.FraudDetection.Specification.Contracts.Strategy;
using System;
using System.Linq;
using System.Threading;

namespace Refactoring.FraudDetection.Specification.Implementations.Factory
{
    public class SpecificationFactory : ISpecificationFactory
    {
        #region Properties
        private readonly ICustomCache _customCache;
        private readonly Mutex _mutex;
        #endregion

        #region Ctors.
        public SpecificationFactory(ICustomCache cacheComponent)
        {
            _customCache = cacheComponent;
            _mutex = new Mutex();
        }
        #endregion

        #region Public_Methods
        public T GetSpecification<T, TParam>() where T : class, ISpecification<TParam>
        {
            var validationName = typeof(T).FullName;

            var validationInstance = default(T);

            if (_customCache.ContainsKey(validationName))
            {
                validationInstance = _customCache.TryGetValue<T>(validationName);
            }
            else
            {
                try
                {
                    if (_mutex.WaitOne())
                    {
                        var constructorInfo = typeof(T).GetConstructor(Type.EmptyTypes);
                        if (constructorInfo != null)
                        {
                            validationInstance = (T)constructorInfo.Invoke(null);

                            if (!_customCache.ContainsKey(validationName))
                                _customCache.TryAdd(validationName, validationInstance);
                        }
                    }
                }
                finally
                {
                    _mutex.ReleaseMutex();
                }
            }

            return validationInstance;
        }

        public T GetSpecificationStrategy<T>(params object[] objects) where T : class, ISpecificationStrategy
        {
            var validationName = typeof(T).FullName;

            var validationInstance = default(T);

            if (_customCache.ContainsKey(validationName))
            {
                validationInstance = _customCache.TryGetValue<T>(validationName);
            }
            else
            {
                try
                {
                    if (_mutex.WaitOne())
                    {
                        var constructorInfo = typeof(T).GetConstructor(objects.Select(objectInstance => objectInstance.GetType()).ToArray());
                        if (constructorInfo != null)
                        {
                            validationInstance = (T)constructorInfo.Invoke(objects);

                            if (!_customCache.ContainsKey(validationName))
                                _customCache.TryAdd(validationName, validationInstance);
                        }
                    }
                }
                finally
                {
                    _mutex.ReleaseMutex();
                }
            }

            return validationInstance;
        }
        #endregion
    }
}
