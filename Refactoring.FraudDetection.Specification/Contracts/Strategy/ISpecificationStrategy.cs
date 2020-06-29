using Refactoring.FraudDetection.Specification.Dto;

namespace Refactoring.FraudDetection.Specification.Contracts.Strategy
{
    public interface ISpecificationStrategy
    {
        bool IsSatisfiedBy(SpecificationDto dtoFrom, SpecificationDto dtoTo);
    }
}
