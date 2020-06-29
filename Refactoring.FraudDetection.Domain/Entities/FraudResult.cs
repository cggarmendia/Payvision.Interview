namespace Refactoring.FraudDetection.Domain.Entities
{
    public class FraudResult
    {
        public int OrderId { get; set; }

        public bool IsFraudulent { get; set; }
    }
}
