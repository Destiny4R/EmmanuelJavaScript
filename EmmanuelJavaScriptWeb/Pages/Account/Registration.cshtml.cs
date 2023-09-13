using EmmanuelJavaScriptWeb.Models.Data;
using EmmanuelJavaScriptWeb.Models;
using EmmanuelJavaScriptWeb.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmmanuelJavaScriptWeb.Pages.Account
{
    public class RegistrationModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ApplicationDbContext dbContext;

        [BindProperty]
        public ApplicationUserVM UserVM { get; set; }
        public RegistrationModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext dbContext)
        {
            this.signInManager = signInManager;
            this.dbContext = dbContext;
            this.userManager = userManager;
        }
        public void OnGet()
        {
        }
        public async Task< IActionResult> OnPost() 
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new()
                {
                    Name = UserVM.Name,
                    UserName = UserVM.Email,
                    Email = UserVM.Email
                };
                var result = await userManager.CreateAsync(user, UserVM.Password);
                if (result.Succeeded)
                {
                    var result2 = await signInManager.PasswordSignInAsync(UserVM.Email, UserVM.Password,false, false);
                    if (result2.Succeeded) { 
                    return RedirectToPage("/Index");
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return Page();
        }
    }
}
