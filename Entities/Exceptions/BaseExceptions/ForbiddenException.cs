namespace DomainModel.Exceptions.BaseExceptions
{
    public class ForbiddenException(string message) : Exception($"Access is blocked: '{message}'")
    {
    }
}
