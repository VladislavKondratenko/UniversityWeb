using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using University.Services.Exceptions;

namespace University.Web.Controllers
{
    public class ErrorController : Controller
    {
        [Route("/Error")]
        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            return exception.Error switch
            {
                GroupIsNotEmptyException e =>
                    RedirectToAction("Index", "Group", new {courseId = e.CourseId}),

                _ => RedirectToAction("Index", "Home")
            };
        }
    }
}