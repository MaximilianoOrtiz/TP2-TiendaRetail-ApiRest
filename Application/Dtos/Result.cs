using System.Net;

namespace Aplication.Dtos
{
    public class Result
    {
        public object Data { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }

        public Result(object data, HttpStatusCode httpStatusCode)
        {
            Data = data;
            HttpStatusCode = httpStatusCode;
        }
    }
}
