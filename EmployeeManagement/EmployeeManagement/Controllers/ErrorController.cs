using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;
        }

        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var StatusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            switch(statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry😔, The Requested Resources couldn't be found";
                    logger.LogWarning($"404 Error occured. Path = {StatusCodeResult.OriginalPath} and Query String = {StatusCodeResult.OriginalQueryString}");
                    //ViewBag.Path = HttpStatusCodeResult.OriginalPath;
                    //ViewBag.QS = HttpStatusCodeResult.OriginalQueryString;
                    break;
            }
            return View("NotFound");
        }

        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var ExceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            logger.LogError($"The Part {ExceptionDetails.Path} threw an exception {ExceptionDetails.Error}");

            //ViewBag.ExceptionPath = ExceptionDetails.Path;
            //ViewBag.ErrorMessage = ExceptionDetails.Error.Message;
            //ViewBag.StackTrace = ExceptionDetails.Error.StackTrace;

            return View("Error");
        }


    }
}
