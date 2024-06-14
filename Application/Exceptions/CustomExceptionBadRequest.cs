namespace Application.Exceptions
{
    public class CustomExceptionBadRequest : Exception
    {
        public CustomExceptionBadRequest(string message) : base(message)
        {
        }
    }
}
