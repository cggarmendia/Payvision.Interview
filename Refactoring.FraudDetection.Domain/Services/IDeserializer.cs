using Refactoring.FraudDetection.Domain.Entities;
using System.Collections.Generic;

namespace Refactoring.FraudDetection.Domain.Services
{
    public interface IDeserializer
    {
        IEnumerable<Order> DeserializeOrder(IEnumerable<string> orders);
    }
}
