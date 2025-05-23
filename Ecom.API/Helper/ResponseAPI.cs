﻿namespace Ecom.API.Helper
{
    public class ResponseAPI
    {
        public ResponseAPI(int statusCode, string? message=null)
        {
            StatusCode = statusCode;
            Message = message??GetMessageFromStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string? Message { get; set; }
        private string? GetMessageFromStatusCode(int statusCode)
        {
            return statusCode switch
            {
                200 =>"Done",
                400 =>"Bad Request",
                401 =>"Un Authorized",
                500 =>"Server Error",
                404=>"Not Found Resources",
                _ =>null
            };

        }
    }
}
