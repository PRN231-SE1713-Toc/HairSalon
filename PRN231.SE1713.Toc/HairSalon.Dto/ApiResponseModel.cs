using System.Net;

namespace HairSalon.Dto
{
    /// <summary>
    /// API response model for HTTP actions except GET
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public record ApiResponseModel<T>
    {
        public HttpStatusCode StatusCode { get; set; }

        public required string Message { get; set; }

        public T? Data { get; set; }
    }
}
