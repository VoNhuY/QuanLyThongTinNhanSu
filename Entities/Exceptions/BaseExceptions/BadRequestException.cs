namespace DomainModel.Exceptions.BaseExceptions
{
    public abstract class BadRequestException : Exception
    {
        protected BadRequestException(string message) : base($"The request was interrupted: '{message}'")
        {
        }
    }
}
