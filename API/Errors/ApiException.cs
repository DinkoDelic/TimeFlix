namespace API.Errors
{
    public class ApiException : ApiResponse
    {
        //Extension of ApiResponse to provide more detailed exception information for developer
        public ApiException(int statusCode, string message = null, string details = null) : base(statusCode, message)
        {
            Details = details;
        }

        public string Details { get; set; }
    }
}