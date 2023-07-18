using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VermilionTimeline.Frontend.Models;
using VermilionTimeline.Frontend.Models.Forms;
using VermilionTimeline.IdentityDataAccess;
using VermilionTimeline.MainDataAccess;
using VermilionTimeline.MainDataAccess.Entities;
using VermilionTimeline.MainDataAccess.Repositories;

namespace VermilionTimeline.Frontend.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly AccountRepository accountRepository;

        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            AccountRepository accountRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.accountRepository = accountRepository;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            // create user
            var user = await userManager.FindByNameAsync(registerModel.Email);
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = registerModel.Email,
                    Email = registerModel.Email,
                };
                var userResult = await userManager.CreateAsync(user, registerModel.Password);
                if (false == userResult.Succeeded)
                {
                    registerModel.Messages = userResult.Errors.Select(e => e.Description).ToArray();
                    return View(registerModel);
                }
            }

            // check whether user has the role
            if (true == await userManager.IsInRoleAsync(user, IdentityRoles.User))
            {
                registerModel.Messages = new string[] {
                    "The user has already registered."
                };
                return View(registerModel);
            }

            // grant user role to this user
            var roleResult = await userManager.AddToRoleAsync(user, IdentityRoles.User);
            if (false == roleResult.Succeeded)
            {
                registerModel.Messages = roleResult.Errors.Select(e => e.Description).ToArray();
                return View(registerModel);
            }

            // create account if it is missing
            if (false == await CreateAccountIfMissing(registerModel))
            { 
                return View(registerModel);
            }

            // sign in the new user
            var signInResult = await signInManager.PasswordSignInAsync(registerModel.Email,
                registerModel.Password, false, false);
            if (false == signInResult.Succeeded)
            {
                registerModel.Messages = new string[] {
                    "Failed to sign in the new user."
                };
                return View(registerModel);
            }

            // all done, redirect to home
            return this.RedirectToHome();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(loginModel);
            //}

            // find the user with the username
            var user = await userManager.FindByNameAsync(loginModel.Email);
            if (user == null)
            {
                loginModel.Messages = new string[] {
                    "Failed to log in"
                };
                return View(loginModel);
            }

            // validate the password
            if (false == await userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                loginModel.Messages = new string[] 
                {
                    "Failed to log in"
                };
                return View(loginModel);
            }

            // create account if it is missing
            if (false == await CreateAccountIfMissing(loginModel))
            {
                return View(loginModel);
            }

            // sign in the user
            var signInResult = await signInManager.PasswordSignInAsync(loginModel.Email,
                loginModel.Password, false, false);
            if (false == signInResult.Succeeded)
            {
                loginModel.Messages = new string[] 
                {
                    "Failed to log in"
                };
                return View(loginModel);
            }

            return this.RedirectToHome();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return this.RedirectToHome();
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        async Task<bool> CreateAccountIfMissing(AccountModel accountModel)
        {
            var account = await accountRepository.FindAsync(accountModel.Email);
            if (account == null)
            {
                // create account
                account = new Account()
                {
                    Id = Guid.NewGuid(),
                    FullName = accountModel.Email,
                };
                var claims = new AccountClaim[]
                {
                    new AccountClaim()
                    {
                        Id = Guid.NewGuid(),
                        AccountId = account.Id,
                        Type = AccountClaimTypes.Email,
                        Value = accountModel.Email,
                        ValueType = typeof(string).ToString()
                    }
                };
                var accountResult = await accountRepository.CreateAsync(account, claims);
                if (false == accountResult.Succeeded)
                {
                    accountModel.Messages = accountResult.Errors.Select(e => e.Description).ToArray();
                    return false;
                }
            }

            return true;
        }
    }
}
