using BookMyShow.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;

namespace BookMyShow.Filters
{
    public class ValidateTokenAttribute : IActionFilter
    {
        private readonly ILoggerManager _logger;
        public ValidateTokenAttribute(ILoggerManager logger)
        {

            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
           
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
                var authorizationToken = StringValues.Empty;
                if (context.HttpContext.Request.Headers.TryGetValue("Authorization", out authorizationToken))
                {

                    if (!ValidateToken(authorizationToken.ToString()))
                    {
                        _logger.LogInfo("Path is forbidden");
                        context.Result = new ForbidResult();
                    }

                }
                else
                {
                    context.Result = new ForbidResult();
                }
         }
        
        private bool ValidateToken(string token)
        {
            byte[] data = Convert.FromBase64String(token);
            DateTime when = DateTime.FromBinary(BitConverter.ToInt64(data, 0));
            if (when < DateTime.UtcNow.AddHours(-24))
            {
                return false;
            }
            return true;
        }
    }
}
