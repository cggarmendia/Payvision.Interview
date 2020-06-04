using Refactoring.FraudDetection.Contracts;
using Refactoring.FraudDetection.Dto;
using System;
using System.Collections.Generic;

namespace Refactoring.FraudDetection.Implementations
{
    public class Normalizer : INormalizer
    {
        #region Public_Methods
        public void NormalizeOrders(IEnumerable<Order> orders)
        {
            foreach (var order in orders)
            {
                order.Email = NormalizeEmail(order.Email);

                order.Street = NormalizeStreet(order.Street);

                order.State = NormalizeState(order.State);
            }
        }
        #endregion

        #region Private_Methods
        private string NormalizeEmail(string email)
        {
            var aux = email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            return string.Join("@", new string[] { aux[0], aux[1] });
        }

        private string NormalizeStreet(string street)
        {
            return street.Replace("st.", "street").Replace("rd.", "road");
        }

        private string NormalizeState(string state)
        {
            return state.Replace("il", "illinois").Replace("ca", "california").Replace("ny", "new york");
        }
        #endregion
    }
}
