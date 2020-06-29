using Refactoring.FraudDetection.Specification.Dto;

namespace Refactoring.FraudDetection.Specification.Contracts
{
    public interface ISpecification<in T>
    {
        bool IsSatisfiedBy(T dtoFrom, T dtoTo);
    }
}
