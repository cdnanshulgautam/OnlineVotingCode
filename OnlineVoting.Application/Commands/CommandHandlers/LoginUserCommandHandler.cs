using MediatR;
using Microsoft.AspNetCore.Identity;
using OnlineVoting.Application.Commands.Command;
using OnlineVoting.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Application.Commands.CommandHandlers
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, bool>
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public LoginUserCommandHandler(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<bool> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null || !user.IsAuthorized) { return false; }
            var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, request.RememberMe,
                lockoutOnFailure: false);
            return result.Succeeded;
        }
    }
}
