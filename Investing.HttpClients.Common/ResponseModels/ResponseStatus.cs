using System.Net;

namespace Investing.HttpClients.Common.ResponseModels
{
    public class ResponseStatus
    {
        public string Name { get; }

        public string Message { get; }

        public HttpStatusCode? Code { get; }

        public ResponseStatus(string message, HttpStatusCode? code)
        {
            if (string.IsNullOrEmpty(message)) throw new ArgumentNullException(nameof(message));

            Name = nameof(code);
            Message = message;
            Code = code;
        }

        public ResponseStatus(string message, HttpResponseMessage response)
        {
            if (string.IsNullOrEmpty(message)) throw new ArgumentNullException(nameof(message));
            if (response == null) throw new ArgumentNullException(nameof(response));

            Name = nameof(response.StatusCode);
            Message = message;
            Code = response.StatusCode;
        }

        public ResponseStatus(HttpResponseMessage response)
        {
            if (response == null) throw new ArgumentNullException(nameof(response));

            Name = nameof(response.StatusCode);
            Message = nameof(response.StatusCode);
            Code = response.StatusCode;
        }
    }
}
