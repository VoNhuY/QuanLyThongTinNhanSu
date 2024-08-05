namespace DomainModel.Exceptions.BaseExceptions
{
    public class UnauthorizedException(string message) : Exception($"Not have access: '{message}'")
    {
    }
}
