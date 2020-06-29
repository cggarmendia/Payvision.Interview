using Refactoring.FraudDetection.Specification.Contracts;
using Refactoring.FraudDetection.Specification.Dto.Order;

namespace Refactoring.FraudDetection.Specification.Implementations.Order
{
    public class IsTheSameAddressButDifferentCreditCardSpec : ISpecification<AddressAndCreditCardDto>
    {
        public bool IsSatisfiedBy(AddressAndCreditCardDto currentOrder, AddressAndCreditCardDto orderToCompare)
        {
            return currentOrder.State == orderToCompare.State
                        && currentOrder.ZipCode == orderToCompare.ZipCode
                        && currentOrder.Street == orderToCompare.Street
                        && currentOrder.City == orderToCompare.City
                        && currentOrder.CreditCard != orderToCompare.CreditCard;
        }

    }
}
