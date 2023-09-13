using EmmanuelJavaScriptWeb.Models.Data;
using EmmanuelJavaScriptWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EmmanuelJavaScriptWeb.Models.ViewModels;

namespace EmmanuelJavaScriptWeb.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ApplicationDbContext dbContext;
        [BindProperty]
        public ApplicationUserLogin model { get; set; }
        public LoginModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext dbContext)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.dbContext = dbContext;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, true);

                if (result.Succeeded)
                {
                    var user = await userManager.FindByEmailAsync(model.Email);
                    var geturl = dbContext.TrackerUsers.FirstOrDefault(h => h.AppId == user.Id);
                    if (geturl != null)
                    {
                        return RedirectToPage(geturl.WebUrl);
                    }
                    return RedirectToPage("/Index");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return Page();
        }
    }
}
