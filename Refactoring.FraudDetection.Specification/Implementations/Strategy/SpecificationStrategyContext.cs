using Refactoring.FraudDetection.Specification.Contracts.Factory;
using Refactoring.FraudDetection.Specification.Contracts.Strategy;
using Refactoring.FraudDetection.Specification.Dto;
using Refactoring.FraudDetection.Specification.Enum;
using System.Collections.Generic;

namespace Refactoring.FraudDetection.Specification.Implementations.Strategy
{
    public class SpecificationStrategyContext : ISpecificationStrategyContext
    {
        #region Properties
        public Dictionary<FraudDetectionStrategiesEnum, ISpecificationStrategy> FraudDetectionStrategies { get; set; }
        private ISpecificationStrategy SpecificationStrategy { get; set; }
        private readonly ISpecificationFactory _specificationFactory;
        #endregion

        #region Ctor.
        public SpecificationStrategyContext(ISpecificationFactory specificationFactory)
        {
            _specificationFactory = specificationFactory;
            InitializeFraudDetectionStrategies();
        }

        private void InitializeFraudDetectionStrategies()
        {
            FraudDetectionStrategies = new Dictionary<FraudDetectionStrategiesEnum, ISpecificationStrategy>() 
            {
                { FraudDetectionStrategiesEnum.Juliet, _specificationFactory.GetSpecificationStrategy<JulietStrategy>(_specificationFactory) }
            };
        }
        #endregion

        #region Public_Methods
        public void SetStrategy(FraudDetectionStrategiesEnum strategyEnum)
        {
            if (FraudDetectionStrategies.ContainsKey(strategyEnum))
            {
                SpecificationStrategy = FraudDetectionStrategies[strategyEnum];
            }
            else 
            {
                //ToDo
            }
        }

        public bool IsSatisfiedBy(SpecificationDto dtoFrom, SpecificationDto dtoTo)
        {
            return SpecificationStrategy.IsSatisfiedBy(dtoFrom, dtoTo);
        }
        #endregion
    }
}
