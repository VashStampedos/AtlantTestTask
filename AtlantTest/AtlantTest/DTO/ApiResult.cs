using System.Net;

namespace AtlantTest.DTO
{
    public class ApiResult<T>
    {
        public bool Succeeded { get; set; }
        public IEnumerable<string> Messages { get; set; }
        public HttpStatusCode Code { get; set; }
        public T Data{ get; set; }

        public ApiResult(bool succeeded, HttpStatusCode code, IEnumerable<string> messages, T data)
        {
            Succeeded = succeeded; 
            Code = code; 
            Messages = messages;
            Data = data;

        }

        public static ApiResult<T> Success(T data) => new ApiResult<T>(true, HttpStatusCode.OK, Enumerable.Empty<string>(), data);
        public static ApiResult<T> Failure(HttpStatusCode code, IEnumerable<string> messages) => new ApiResult<T>(false, code, messages, default);
       

    }
}
