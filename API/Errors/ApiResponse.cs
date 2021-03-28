using System;

namespace API.Errors
{
    // Custom response to handle bad requests
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;

            // If there is no message, return custom default message
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }


        public int StatusCode { get; }
        public string Message { get; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            // returns appropriate information based on status code
            return statusCode switch
            {
                400 => "You made a bad request",
                401 => "Not authorized",
                404 => "Resource was not found",
                500 => "Server error",
                _ => null
            };
        }
    }
}