using Refactoring.FraudDetection.Domain.Entities;
using System.Collections.Generic;

namespace Refactoring.FraudDetection.Contracts
{
    public interface IFraudInspector
    {
        IEnumerable<FraudResult> InspectOrders(IList<Order> orders);
    }
}