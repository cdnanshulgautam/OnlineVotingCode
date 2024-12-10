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
    public class DeleteVoteGroupCommandHandler : IRequestHandler<DeleteVoteGroupCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteVoteGroupCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteVoteGroupCommand request, CancellationToken cancellationToken)
        {
            var voteGroup = _unitOfWork.VoteGroups.GetById(request.GroupId);
            if (voteGroup == null)
            {
                return false;
            }
            _unitOfWork.VoteGroups.Delete(voteGroup);
            var result = await _unitOfWork.CompleteAsync();
            return result > 0;
        }
    }
}
