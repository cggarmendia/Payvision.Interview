using Refactoring.FraudDetection.Specification.Dto;
using Refactoring.FraudDetection.Specification.Dto.Order;

namespace Refactoring.FraudDetection.Specification.Implementations
{
    public static class SpecificationDtoBuilder
    {
        public static EmailAndCreditCardDto GetEmailAndCreditCardDto(SpecificationDto dtoFrom)
        {
            return new EmailAndCreditCardDto()
            {
                Email = dtoFrom.Email,
                CreditCard = dtoFrom.CreditCard
            };
        }

        public static AddressAndCreditCardDto GetAddressAndCreditCardDto(SpecificationDto dtoFrom)
        {
            return new AddressAndCreditCardDto()
            {
                City = dtoFrom.City,
                CreditCard = dtoFrom.CreditCard,
                State = dtoFrom.State,
                Street = dtoFrom.Street,
                ZipCode = dtoFrom.ZipCode
            };
        }
    }
}
