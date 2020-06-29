using Refactoring.FraudDetection.Contracts;
using Refactoring.FraudDetection.Domain.Entities;
using System.Collections.Generic;

namespace Refactoring.FraudDetection.Implementations
{
    public class FraudInspector : IFraudInspector
    {
        #region Public_Methods
        public IEnumerable<FraudResult> InspectOrders(IList<Order> orders)
        {
            var fraudResults = new List<FraudResult>();

            for (int i = 0; i < orders.Count; i++)
            {
                var currentOrder = orders[i];

                for (int j = i + 1; j < orders.Count; j++)
                {
                    var orderToCompare = orders[j];

                    if (currentOrder.DealId == orderToCompare.DealId)
                    {
                        if (IsTheSameEmailButDifferentCreditCard(currentOrder, orderToCompare)
                            || IsTheSameAddressButDifferentCreditCard(currentOrder, orderToCompare))
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
        private static bool IsTheSameEmailButDifferentCreditCard(Order currentOrder, Order orderToCompare)
        {
            return currentOrder.Email == orderToCompare.Email
                && currentOrder.CreditCard != orderToCompare.CreditCard;
        }

        private static bool IsTheSameAddressButDifferentCreditCard(Order currentOrder, Order orderToCompare)
        {
            return currentOrder.State == orderToCompare.State
                        && currentOrder.ZipCode == orderToCompare.ZipCode
                        && currentOrder.Street == orderToCompare.Street
                        && currentOrder.City == orderToCompare.City
                        && currentOrder.CreditCard != orderToCompare.CreditCard;
        }
        #endregion
    }
}
