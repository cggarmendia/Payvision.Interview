using Refactoring.FraudDetection.Dto;
using System.Collections.Generic;

namespace Refactoring.FraudDetection.Contracts
{
    public interface IFraudInspector
    {
        IEnumerable<FraudResult> InspectOrders(IList<Order> orders);
    }
}