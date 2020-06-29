using Refactoring.FraudDetection.Specification.Contracts;
using Refactoring.FraudDetection.Specification.Dto.Order;

namespace Refactoring.FraudDetection.Specification.Implementations.Order
{
    public class IsTheSameEmailButDifferentCreditCardSpec : ISpecification<EmailAndCreditCardDto>
    {
        public bool IsSatisfiedBy(EmailAndCreditCardDto currentOrder, EmailAndCreditCardDto orderToCompare)
        {
            return currentOrder.Email == orderToCompare.Email
                 && currentOrder.CreditCard != orderToCompare.CreditCard;
        }
    }
}
