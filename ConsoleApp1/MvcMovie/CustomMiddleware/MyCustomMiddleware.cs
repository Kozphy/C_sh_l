namespace MiddlewareExample.CustomMiddleware
{
    public class MyCustomMiddleware : IMiddleware
    {
        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            throw new NotImplementedException();
        }
    }

}