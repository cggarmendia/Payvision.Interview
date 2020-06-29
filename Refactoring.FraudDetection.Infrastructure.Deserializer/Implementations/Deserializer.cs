using Refactoring.FraudDetection.Domain.Entities;
using Refactoring.FraudDetection.Domain.Services;
using System;
using System.Collections.Generic;

namespace Refactoring.FraudDetection.Infrastructure.Deserializer.Implementations
{
    public class Deserializer : IDeserializer
    {
        #region Public_Methods
        public IEnumerable<Order> DeserializeOrder(IEnumerable<string> orders)
        {
            foreach (var order in orders)
            {
                var orderSplited = order.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                yield return new Order
                {
                    OrderId = int.Parse(orderSplited[0]),
                    DealId = int.Parse(orderSplited[1]),
                    Email = orderSplited[2].ToLower(),
                    Street = orderSplited[3].ToLower(),
                    City = orderSplited[4].ToLower(),
                    State = orderSplited[5].ToLower(),
                    ZipCode = orderSplited[6],
                    CreditCard = orderSplited[7]
                };
            }
        }
        #endregion
    }
}
