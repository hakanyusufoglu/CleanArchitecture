using CleanArchitecture.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace CleanArchitecture.Api.ExceptionHandler
{
    public class CriticalExceptionHandler : IExceptionHandler
    {
        public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            //business logic
            
            if(exception is CriticalException)
                Console.WriteLine("example: send email for exception");

            return ValueTask.FromResult(false);
        }
    }
}
