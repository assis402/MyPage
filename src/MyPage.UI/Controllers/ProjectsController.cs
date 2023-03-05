using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using MyPage.UI.Models;
using System.Diagnostics;

namespace MyPage.UI.Controllers
{
    public class ProjectsController : Controller
    {
        public ProjectsController()
        {
        }

        public async Task<IActionResult> IndexAsync()
        {
            var url = "https://api.github.com/orgs/assis402/repos";

            var test = await url.WithHeader("Accept", "application/vnd.github+json")
                                .WithHeader("Authorization", "Bearer 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")
                                .GetJsonAsync();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}