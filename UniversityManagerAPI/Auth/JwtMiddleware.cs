namespace UniversityManagerAPI.Auth
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate next;

        public JwtMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault() ?? string.Empty;
            var userId = jwtUtils.ValidateJwtToken(token);

            if(userId != null) 
            {
                context.Items["User"] = userId;
            }

            await next(context);
        }
    }
}
