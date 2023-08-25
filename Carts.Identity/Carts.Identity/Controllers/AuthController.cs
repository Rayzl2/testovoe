using Carts.Identity.Data;
using Carts.Identity.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Carts.Identity.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<AppClient> _signInManager;
        private readonly UserManager<AppClient> _userManager;
        private readonly IIdentityServerInteractionService _interaction;

        public AuthController(SignInManager<AppClient> signInManager, UserManager<AppClient> userManager,
            IIdentityServerInteractionService interaction)
        {
            (_signInManager, _userManager, _interaction) = (signInManager, userManager, interaction);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            var viewModel = new AuthViewModel { 
                ReturnUrl = returnUrl
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task <IActionResult> Login(AuthViewModel viewModel) 
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Model state is not valid!");
            }

            var client = await _userManager.FindByIdAsync(viewModel.machineId);
            Console.WriteLine(client);
            var result = await _signInManager.PasswordSignInAsync(viewModel.machineId, viewModel.key, false, false);
            Console.WriteLine($"{result}");
            return View(viewModel.ReturnUrl); 
        }

        [HttpGet]

        public async Task <IActionResult> Logout (string logoutid)
        {
            await _signInManager.SignOutAsync();
            var logoutReq = await _interaction.GetLogoutContextAsync(logoutid);

            return Redirect(logoutReq.PostLogoutRedirectUri);
        }
    }
}
