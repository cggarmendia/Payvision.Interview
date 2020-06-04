using Refactoring.FraudDetection.Dto;
using System.Collections.Generic;

namespace Refactoring.FraudDetection.Contracts
{
    public interface IOrderDeserializer
    {
        IEnumerable<Order> Deserialize(IEnumerable<string> orders);
    }
}