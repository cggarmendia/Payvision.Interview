using Refactoring.FraudDetection.Dto;
using System.Collections.Generic;

namespace Refactoring.FraudDetection.Contracts
{
    public interface INormalizer
    {
        void NormalizeOrders(IEnumerable<Order> orders);
    }
}