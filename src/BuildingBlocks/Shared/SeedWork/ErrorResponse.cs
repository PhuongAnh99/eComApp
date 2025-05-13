using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.SeedWork
{
    public class ErrorResponse
    {
        public string Error { get; set; }
        public string? Details { get; set; }

        public ErrorResponse(string error, string? details = null)
        {
            Error = error;
            Details = details;
        }
    }
}
