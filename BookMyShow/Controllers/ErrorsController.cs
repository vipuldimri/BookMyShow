using BookMyShow.Interfaces;
using BookMyShow.Models.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;
namespace BookMyShow.Controllers
{
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        private readonly ILoggerManager _logger;

        public ErrorsController(ILoggerManager logger)
        {
            _logger = logger;
        }

        [Route("error")]
        public object Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error;
            var code = (int)HttpStatusCode.InternalServerError;

            if (exception is BusinessException){
                _logger.LogInfo("Bussiness Exception Start");
                BusinessException ex = (BusinessException)exception;
                foreach (var item in ex.errorMessages)
                {
                    ModelState.AddModelError(item.message, item.message);
                    _logger.LogInfo("Key - " + item.message + ", Value - " + item.message);
                }
                _logger.LogInfo("Bussiness Exception End");
                return BadRequest(ModelState);
            }
            else{
                _logger.LogError(exception.Message);
            }

            Response.StatusCode = code;
            return new ErrorDetails(code, $"Something went wrong please contact admin.");
        }
    }
}
