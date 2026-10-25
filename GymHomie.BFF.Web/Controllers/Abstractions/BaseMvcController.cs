using Microsoft.AspNetCore.Mvc;

namespace GymHomie.BFF.Web.Controllers.Abstractions
{
    public abstract class BaseMvcController : Controller
    {
        protected IActionResult HandleViewResponse<T>(string viewName, string title, T model)
        {
            ViewBag.Title = title;
            return View(viewName: viewName, model: model);
        }
    }
}
