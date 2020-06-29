using Refactoring.FraudDetection.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.FraudDetection.Domain.Services
{
    public interface INormalizer
    {
        void NormalizeOrders(IEnumerable<Order> orders);
        string NormalizeEmail(string email);
        string NormalizeStreet(string street);
        string NormalizeState(string state);
    }
}
