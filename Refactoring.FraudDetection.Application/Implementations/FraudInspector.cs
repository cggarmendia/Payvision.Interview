using Refactoring.FraudDetection.Contracts;
using Refactoring.FraudDetection.Domain.Entities;
using Refactoring.FraudDetection.Specification.Contracts.Strategy;
using Refactoring.FraudDetection.Specification.Dto;
using Refactoring.FraudDetection.Specification.Enum;
using System;
using System.Collections.Generic;

namespace Refactoring.FraudDetection.Implementations
{
    public class FraudInspector : IFraudInspector
    {
        private readonly ISpecificationStrategyContext _specificationContext;

        public FraudInspector(ISpecificationStrategyContext specificationContext)
        {
            _specificationContext = specificationContext;
        }

        #region Public_Methods
        public IEnumerable<FraudResult> InspectOrders(IList<Order> orders, FraudDetectionStrategiesEnum strategiesEnum)
        {
            var fraudResults = new List<FraudResult>();
            _specificationContext.SetStrategy(strategiesEnum);

            for (int i = 0; i < orders.Count; i++)
            {
                var currentOrder = orders[i];

                for (int j = i + 1; j < orders.Count; j++)
                {
                    var orderToCompare = orders[j];

                    if (currentOrder.DealId == orderToCompare.DealId)
                    {
                        if (_specificationContext.IsSatisfiedBy(GetSpecificationDto(currentOrder), 
                            GetSpecificationDto(orderToCompare)))
                        {
                            fraudResults.Add(new FraudResult
                            {
                                IsFraudulent = true,
                                OrderId = orderToCompare.OrderId
                            });
                        }
                    }
                }
            }

            return fraudResults;
        }

        #endregion

        #region Private_Methods
        private SpecificationDto GetSpecificationDto(Order order)
        {
            return new SpecificationDto()
            {
                City = order.City,
                CreditCard = order.CreditCard,
                DealId = order.DealId,
                Email = order.Email,
                OrderId = order.OrderId,
                State = order.State,
                Street = order.Street,
                ZipCode = order.ZipCode
            };
        }
        #endregion
    }
}
