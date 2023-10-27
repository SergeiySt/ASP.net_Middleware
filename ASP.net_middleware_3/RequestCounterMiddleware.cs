namespace ASP.net_middleware_3
{
    public class RequestCounterMiddleware
    {
        private readonly RequestDelegate _next;
        private int requestCount = 0;

        public RequestCounterMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Увеличиваем счетчик запросов при каждом запросе.
            requestCount++;

            // Добавляем заголовок с количеством запросов в ответ.
            context.Response.Headers.Add("X-Request-Count", requestCount.ToString());

            // Пропускаем запрос далее по конвейеру.
            await _next(context);
        }
    }

    public static class RequestCounterMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestCounterMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestCounterMiddleware>();
        }
    }
}
