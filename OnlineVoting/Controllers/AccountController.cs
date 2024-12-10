using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineVoting.Application.Commands.Command;
using OnlineVoting.Application.ViewModels;

namespace OnlineVoting.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var command = new RegisterUserCommand
                {
                    Email = vm.Email,
                    Password = vm.Password,
                    FullName = vm.FullName,
                    Address = vm.Address,
                    DateOfBirth = vm.DateOfBirth,
                    State = vm.State,
                    City = vm.City,
                };
                var result = await _mediator.Send(command);
                if (result)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid Registration");
            }
            return View(vm);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var command = new LoginUserCommand
                {
                    Email = vm.Email,
                    Password = vm.Password,
                    RememberMe = vm.RememberMe
                };
                var result = await _mediator.Send(command);
                if (result)
                {
                    return RedirectToLocal(returnUrl);
                }
                ModelState.AddModelError(string.Empty, "Invalid Attempt");
            }
            return View(vm);
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _mediator.Send(new LogoutUserCommand());
            return RedirectToAction("Index", "Home");
        }
    }
}
