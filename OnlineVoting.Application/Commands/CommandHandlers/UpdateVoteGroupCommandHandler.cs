using MediatR;
using OnlineVoting.Application.Commands.Command;
using OnlineVoting.Domain.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Application.Commands.CommandHandlers
{
    public class UpdateVoteGroupCommandHandler : IRequestHandler<UpdateVoteGroupCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateVoteGroupCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(UpdateVoteGroupCommand request, CancellationToken cancellationToken)
        {
            var voteGroup = _unitOfWork.VoteGroups.GetById(request.GroupId);
            if (voteGroup == null) { return false; }
            voteGroup.GroupName = request.GroupName;
            voteGroup.GroupDescription = request.GroupDescription;
            voteGroup.Symbol = request.GroupImageUrl;
            _unitOfWork.VoteGroups.Update(voteGroup);
            var result = await _unitOfWork.CompleteAsync();
            return result > 0;
        }
    }
}
