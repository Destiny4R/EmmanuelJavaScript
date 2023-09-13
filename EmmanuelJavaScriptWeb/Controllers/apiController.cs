using EmmanuelJavaScriptWeb.Models;
using EmmanuelJavaScriptWeb.Models.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmmanuelJavaScriptWeb.Controllers
{
    public class apiController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;

        public apiController(SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            if (signInManager.IsSignedIn(User))
            {
                await signInManager.SignOutAsync();
                return RedirectToPage("/Index");
            }
            else
            {
                return RedirectToPage("/Index");
            }
        }
    }
}
