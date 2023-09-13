using EmmanuelJavaScriptWeb.Models.Data;
using EmmanuelJavaScriptWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace EmmanuelJavaScriptWeb.Pages.Js_Page
{
    public class JS_String_MethodModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;
        private readonly SignInManager<ApplicationUser> signInManager;

        //public Tracker Tracker { get; set; }
        public JS_String_MethodModel(ApplicationDbContext dbContext, SignInManager<ApplicationUser> signInManager)
        {
            this.dbContext = dbContext;
            this.signInManager = signInManager;
        }
        public void OnGet()
        {
            if (signInManager.IsSignedIn(User))
            {
                var claimIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
                var getdata = dbContext.TrackerUsers.FirstOrDefault(n => n.AppId == claim.Value);
                if (getdata != null)
                {
                    getdata.WebUrl = "/Js-Page/JS-String-Method";
                }
                else
                {
                    Tracker tr = new()
                    {
                        WebUrl = "/Js-Page/JS-String-Method",
                        AppId = claim.Value
                    };
                    dbContext.Add(tr);
                }
                dbContext.SaveChanges();
            }
        }
    }
}
