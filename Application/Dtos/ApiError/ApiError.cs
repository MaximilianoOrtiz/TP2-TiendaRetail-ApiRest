namespace Application.Dtos.ApiError
{
    public class ApiError
    {
        public string Message { get; set; }

        public ApiError(string message)
        {
            this.Message = message;
        }

    }
}
