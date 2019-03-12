namespace ZeroApp.ForecastTracker.Service.Infrastructure.Exceptions
{
    public class EntityNotFoundException : InfrastructureException
    {
        public EntityNotFoundException(string findfBy,string value)
        {
            FindBy = findfBy;
            Value = value;
        }

        public string FindBy { get; }

        public string Value { get; }
    }
}