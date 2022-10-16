using System.Net;

namespace BookShelter.WebAPI.Commons.Exceptions;

public class StatusCodeException : Exception
{
    public HttpStatusCode HttpStatusCode { get; set; }

    public StatusCodeException() { }

    public StatusCodeException(HttpStatusCode httpStatusCode, string message)
        : base(message)
    {
        this.HttpStatusCode = httpStatusCode;
    }
}
