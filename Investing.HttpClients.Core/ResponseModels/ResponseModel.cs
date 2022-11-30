using System.Net;

namespace Investing.HttpClients.Core.ResponseModels
{
    public class ResponseModel<T>
    {
        public T? Result { get; }

        public ResponseStatus Status { get; }

        public ResponseModel(T? result, ResponseStatus status)
        {
            if (status == null) throw new ArgumentNullException(nameof(status));

            Result = result;
            Status = status;
        }

        public ResponseModel(T? result, string message, HttpStatusCode? code) : this(result, new ResponseStatus(message, code))
        {

        }

        public ResponseModel(T? result, string message, HttpResponseMessage response) : this(result, new ResponseStatus(message, response))
        {

        }

        public ResponseModel(T? result, HttpResponseMessage response) : this(result, new ResponseStatus(response))
        {

        }
    }
}
