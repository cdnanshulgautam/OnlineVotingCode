using MediatR;
using Microsoft.AspNetCore.Identity;
using OnlineVoting.Application.Queries.Query;
using OnlineVoting.Application.ViewModels;
using OnlineVoting.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Application.Queries.QueryHandler
{
    public class GetAllVotersQueryHandler : IRequestHandler<GetAllVotersQuery, IEnumerable<VoterViewModel>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public GetAllVotersQueryHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IEnumerable<VoterViewModel>> Handle(GetAllVotersQuery request, CancellationToken cancellationToken)
        {
            var voters = await _userManager.GetUsersInRoleAsync("Voter");
            var voterList = new List<VoterViewModel>();
            foreach (var voter in voters) 
            {
                var voterViewModel = new VoterViewModel
                {
                    UserId = voter.Id,
                    Email = voter.Email,
                    FullName = voter.FullName,
                    IsAuthorized = voter.IsAuthorized,
                    IsLockout = voter.LockoutEnd.HasValue && voter.LockoutEnd.Value > DateTimeOffset.Now
                };
                voterList.Add(voterViewModel);
            }
            return voterList;
        }
    }
}
