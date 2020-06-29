namespace Refactoring.FraudDetection.Specification.Dto.Order
{
    public class AddressAndCreditCardDto
    {
        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string CreditCard { get; set; }
    }
}
