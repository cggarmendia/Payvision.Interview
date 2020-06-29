using Refactoring.FraudDetection.Domain.Entities;
using Refactoring.FraudDetection.Domain.Services;
using System;
using System.Collections.Generic;

namespace Refactoring.FraudDetection.Infrastructure.Normalizer.Implementations
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
        
        public string NormalizeEmail(string email)
        {
            var aux = email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            return string.Join("@", new string[] { aux[0], aux[1] });
        }

        public string NormalizeStreet(string street)
        {
            return street.Replace("st.", "street").Replace("rd.", "road");
        }

        public string NormalizeState(string state)
        {
            return state.Replace("il", "illinois").Replace("ca", "california").Replace("ny", "new york");
        }
        #endregion
    }
}
