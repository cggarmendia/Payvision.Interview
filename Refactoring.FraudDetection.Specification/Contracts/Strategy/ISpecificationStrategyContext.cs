using Refactoring.FraudDetection.Specification.Dto;
using Refactoring.FraudDetection.Specification.Enum;

namespace Refactoring.FraudDetection.Specification.Contracts.Strategy
{
    public interface ISpecificationStrategyContext
    {
        void SetStrategy(FraudDetectionStrategiesEnum strategyEnum);
        bool IsSatisfiedBy(SpecificationDto dtoFrom, SpecificationDto dtoTo);
    }
}
