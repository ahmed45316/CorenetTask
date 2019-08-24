using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PersonalDiary.Service.ReturnType
{
    public class ResponseResult<T> 
    {
        public T Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public ResponseResult()
        {

        }
        public ResponseResult(T data, HttpStatusCode statusCode, string message)
        {
            Data = data;
            StatusCode = statusCode;
            Message = message;
        }
    }
}
