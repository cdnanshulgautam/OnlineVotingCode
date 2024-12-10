using MediatR;
using OnlineVoting.Application.Commands.Command;
using OnlineVoting.Domain.Entities;
using OnlineVoting.Domain.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Application.Commands.CommandHandlers
{
    public class CastVoteCommandHandler : IRequestHandler<CastVoteCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CastVoteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CastVoteCommand request, CancellationToken cancellationToken)
        {
            var user = _unitOfWork.Users.GetById(request.UserId);
            if(user == null || !user.IsAuthorized) { return false; }
            var existingVote = _unitOfWork.Votes.GetAll(v=>v.UserId == request.UserId).FirstOrDefault();
            if (existingVote != null) { return false; }
            var vote = new Vote
            {
                UserId = request.UserId,
                GroupId = request.GroupId,
                VoteDate = DateTime.Now
            };
            await _unitOfWork.Votes.AddAsync(vote);
            var voteGroup = _unitOfWork.VoteGroups.GetById(request.GroupId);
            if(voteGroup != null)
            {
                voteGroup.VotesCount++;
                _unitOfWork.VoteGroups.Update(voteGroup);
            }
            else { return false; }
            var result = await _unitOfWork.CompleteAsync();
            return result > 0;

        }
    }
}
