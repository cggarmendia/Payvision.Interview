using Refactoring.FraudDetection.Specification.Contracts;
using Refactoring.FraudDetection.Specification.Contracts.Factory;
using Refactoring.FraudDetection.Specification.Contracts.Strategy;
using Refactoring.FraudDetection.Specification.Dto;
using Refactoring.FraudDetection.Specification.Dto.Order;
using Refactoring.FraudDetection.Specification.Implementations.Order;

namespace Refactoring.FraudDetection.Specification.Implementations.Strategy
{
    public class JulietStrategy : ISpecificationStrategy
    {
        #region Properties.
        private ISpecification<AddressAndCreditCardDto> _isTheSameAddressButDifferentCreditCardSpec;
        private ISpecification<EmailAndCreditCardDto> _isTheSameEmailButDifferentCreditCardSpec;
        #endregion

        #region Ctor.
        public JulietStrategy(ISpecificationFactory specificationFactory)
        {
            InitializeSpecifications(specificationFactory);
        }
        #endregion

        #region Private_Methods
        private void InitializeSpecifications(ISpecificationFactory specificationFactory)
        {
            _isTheSameAddressButDifferentCreditCardSpec =
                specificationFactory.GetSpecification<IsTheSameAddressButDifferentCreditCardSpec, AddressAndCreditCardDto>();
            _isTheSameEmailButDifferentCreditCardSpec =
                    specificationFactory.GetSpecification<IsTheSameEmailButDifferentCreditCardSpec, EmailAndCreditCardDto>();
        }
        #endregion

        #region Public_Methods
        public bool IsSatisfiedBy(SpecificationDto dtoFrom, SpecificationDto dtoTo)
        {
            return _isTheSameAddressButDifferentCreditCardSpec.IsSatisfiedBy(
                SpecificationDtoBuilder.GetAddressAndCreditCardDto(dtoFrom),
                SpecificationDtoBuilder.GetAddressAndCreditCardDto(dtoTo)) ||
                _isTheSameEmailButDifferentCreditCardSpec.IsSatisfiedBy(
                SpecificationDtoBuilder.GetEmailAndCreditCardDto(dtoFrom),
                SpecificationDtoBuilder.GetEmailAndCreditCardDto(dtoTo));
        }
        #endregion
    }
}