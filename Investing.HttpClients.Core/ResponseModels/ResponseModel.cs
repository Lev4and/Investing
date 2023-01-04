using System.Net;

namespace Investing.HttpClients.Core.ResponseModels
{
    public class ResponseModel<T>
    {
        public bool? IsError { get; }

        public string Message { get; }

        public HttpStatusCode? Code { get; }

        public T? Result { get; }

        public Exception? ResponseException { get; }

        public ResponseModel(T? result, HttpStatusCode? code, string message, bool? isError = false, 
            Exception? exception = null)
        {
            if (string.IsNullOrEmpty(message)) throw new ArgumentNullException(nameof(message));

            IsError = isError;
            Message = message;
            Code = code;
            Result = result;
            ResponseException = exception;
        }

        public ResponseModel(T? result, HttpStatusCode? code, bool? isError = false,
            Exception? exception = null) : this(result, code, code?.ToString() ?? "Unknown", isError, exception)
        {

        }
    }
}
