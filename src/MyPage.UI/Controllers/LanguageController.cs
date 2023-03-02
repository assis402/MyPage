using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace MyPage.UI.Controllers
{
    public class LanguageController : Controller
    {
        [Route("change")]
        public IActionResult Change(string culture)
        {
            var requestCulture = new RequestCulture(culture);
            var cookieOptions = new CookieOptions { Expires = DateTimeOffset.UtcNow.AddMonths(1) };

            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                                    CookieRequestCultureProvider.MakeCookieValue(requestCulture),
                                    cookieOptions);

            var refererUrl = Request.Headers["Referer"];

            return string.IsNullOrEmpty(refererUrl) ? RedirectToAction("index", "home") : Redirect(refererUrl!);
        }
    }
}