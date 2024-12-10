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
    public class CreateVoteGroupCommandHandler : IRequestHandler<CreateVoteGroupCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateVoteGroupCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
        }
        public async Task<bool> Handle(CreateVoteGroupCommand request, CancellationToken cancellationToken)
        {
            var voteGroup = new VoteGroup
            {
                GroupName = request.GroupName,
                GroupDescription = request.GroupDescription,
                Symbol = request.GroupImageUrl,
                VotesCount = 0
            };
            await _unitOfWork.VoteGroups.AddAsync(voteGroup);
            var result = await _unitOfWork.CompleteAsync();
            return result > 0;
        }
    }
}
