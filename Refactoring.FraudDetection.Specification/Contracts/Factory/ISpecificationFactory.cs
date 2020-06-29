using Refactoring.FraudDetection.Specification.Contracts.Strategy;

namespace Refactoring.FraudDetection.Specification.Contracts.Factory
{
    public interface ISpecificationFactory
    {
        T GetSpecification<T, TParam>() where T : class, ISpecification<TParam>;

        T GetSpecificationStrategy<T>(params object[] objects) where T : class, ISpecificationStrategy;
    }
}
