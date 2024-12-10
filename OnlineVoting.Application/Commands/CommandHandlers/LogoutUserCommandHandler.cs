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
    public class LogoutUserCommandHandler : IRequestHandler<LogoutUserCommand, Unit>
    {
        private SignInManager<ApplicationUser> _signInManager;
        public LogoutUserCommandHandler(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager  = signInManager;
        }
        public async Task<Unit> Handle(LogoutUserCommand request, CancellationToken cancellationToken)
        {
            await _signInManager.SignOutAsync();
            return Unit.Value;
        }
    }
}
