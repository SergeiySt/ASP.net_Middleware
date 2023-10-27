using System.Diagnostics;

namespace ASP.net_middleware_2
{
    public class HeaderMiddleware
    {
        public async Task Invoke(HttpContext context, Func<Task> next)
        {
            foreach (var header in context.Request.Headers)
            {
                Debug.WriteLine($"Header: {header.Key}: {header.Value}");
            }

            await next();
        }
    }
}
