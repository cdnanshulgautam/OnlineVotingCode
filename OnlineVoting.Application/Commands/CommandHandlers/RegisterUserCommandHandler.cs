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
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public RegisterUserCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                Email = request.Email,
                UserName = request.Email,
                FullName = request.FullName,
                DateOfBirth = request.DateOfBirth,
                State = request.State,
                City = request.City,
                Address = request.Address,
                IsAuthorized = false,
                HasVoted = false
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Voter");
            }
            return result.Succeeded;
        }
    }
}
