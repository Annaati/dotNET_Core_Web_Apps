using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var HttpStatusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            switch(statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry😔, The Requested Resources couldn't be found";
                    //ViewBag.Path = HttpStatusCodeResult.OriginalPath;
                    //ViewBag.QS = HttpStatusCodeResult.OriginalQueryString;
                    break;
            }
            return View("NotFound");
        }

        [Route("ExceptionHandler")]
        [AllowAnonymous]
        public IActionResult ExceptionHandler()
        {
            var ExceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            ViewBag.ExceptionPath = ExceptionDetails.Path;
            ViewBag.ErrorMessage = ExceptionDetails.Error.Message;
            ViewBag.StackTrace = ExceptionDetails.Error.StackTrace;

            return View("ExceptionHandler");
        }


    }
}
