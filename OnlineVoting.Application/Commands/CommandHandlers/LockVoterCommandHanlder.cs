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
    public class LockVoterCommandHanlder : IRequestHandler<LockVoterCommand, bool>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public LockVoterCommandHanlder(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Handle(LockVoterCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
            {
                return false;
            }
            if (request.Lock)
            {
                await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.UtcNow.AddYears(100));
            }
            else
            {
                await _userManager.SetLockoutEndDateAsync(user, null);
            }
            return true;
        }
    }
}
