using System.Collections.Generic;

namespace API.Errors
{
    // Used to collect validation errors and sent them client-side, configured in Startup.ConfigureServices
    public class ApiValidationErrorResponse : ApiResponse
    {
        public ApiValidationErrorResponse() : base(400)
        {
        }

        public IEnumerable<string> Errors { get; set; }
    }
}