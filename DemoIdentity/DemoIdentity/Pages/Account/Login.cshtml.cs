using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoIdentity.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInManager;

        [BindProperty]
        public LoginViewModel loginViewModel { get; set; }

        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsyc()
        {
            if (!ModelState.IsValid) return Page();

            var result = await signInManager.PasswordSignInAsync(
                loginViewModel.Email,
                loginViewModel.Password,
                false,
                false
            );

            if (!result.Succeeded)
            {
               
                ModelState.AddModelError("register", "Failed to login");
                return Page();
            }

            return Page();
        }

    }

    public class LoginViewModel {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
