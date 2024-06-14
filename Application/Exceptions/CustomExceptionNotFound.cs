namespace Application.Exceptions
{
    public class CustomExceptionNotFound : Exception
    {
        public CustomExceptionNotFound(string message) : base(message)
        {
        }
    }
}
