using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare_Api_Dto
{
    public class ResponseDto<T>
    {
        public bool Success { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public T Result { get; set; }
        public string Message { get; set; }

        public ResponseDto()
        {
            this.Success = true;
            this.StatusCode = HttpStatusCode.OK;
        }

        public void Error(HttpStatusCode statusCode, string message)
        {
            this.Success = false;
            this.StatusCode = statusCode;
            this.Message = message;
            this.Result = default(T);
        }
    }
}
