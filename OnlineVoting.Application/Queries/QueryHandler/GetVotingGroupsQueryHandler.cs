using MediatR;
using OnlineVoting.Application.Queries.Query;
using OnlineVoting.Application.ViewModels;
using OnlineVoting.Domain.Entities;
using OnlineVoting.Domain.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Application.Queries.QueryHandler
{
    public class GetVotingGroupsQueryHandler : IRequestHandler<GetVotingGroupsQuery, VotingPageViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetVotingGroupsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
        }
        public Task<VotingPageViewModel> Handle(GetVotingGroupsQuery request, CancellationToken cancellationToken)
        {
            var voteGroups = _unitOfWork.VoteGroups.GetAll();
            var HasVoted = _unitOfWork.Votes.GetVotesByUserId(request.UserId).Any();
            var voteViewModels = voteGroups.Select(vg => new VoteViewModel
            {
                GroupId = vg.Id,
                GroupName = vg.GroupName,
                GroupDescription = vg.GroupDescription,
                HasVoted = HasVoted,
            }).ToList();
            var model = new VotingPageViewModel
            {
                VoteGroups = voteViewModels,
                UserHasVoted = HasVoted,
            };
            return Task.FromResult(model);
        }
    }
}
