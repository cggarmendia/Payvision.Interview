using Refactoring.FraudDetection.Domain.Entities;
using Refactoring.FraudDetection.Specification.Enum;
using System.Collections.Generic;

namespace Refactoring.FraudDetection.Contracts
{
    public interface IFraudInspector
    {
        IEnumerable<FraudResult> InspectOrders(IList<Order> orders, FraudDetectionStrategiesEnum strategiesEnum);
    }
}