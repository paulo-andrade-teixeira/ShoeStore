namespace CleanArchitecture.Domain.Exceptions
{
    public class DomainValidationException(string entity, IEnumerable<string> errorMessages) : Exception(string.Join(";",errorMessages))
    {
        public string Entity { get; init; } = entity;
        public IEnumerable<string> ErrorMessages { get; init; } = errorMessages;
    }
}
