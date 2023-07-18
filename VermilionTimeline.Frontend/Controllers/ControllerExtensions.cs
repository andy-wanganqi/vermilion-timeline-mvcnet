using Microsoft.AspNetCore.Mvc;

namespace VermilionTimeline.Frontend.Controllers
{
    public static class ControllerExtensions
    {
        public static RedirectToActionResult RedirectToHome(this Controller controller) 
            => controller.RedirectToAction("Index", "Home");
    }
}
