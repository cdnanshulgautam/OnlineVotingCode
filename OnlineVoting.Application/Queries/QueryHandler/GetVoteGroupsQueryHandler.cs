using MediatR;
using OnlineVoting.Application.Queries.Query;
using OnlineVoting.Domain.Entities;
using OnlineVoting.Domain.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Application.Queries.QueryHandler
{
    public class GetVoteGroupsQueryHandler : IRequestHandler<GetVoteGroupsQuery, IEnumerable<VoteGroup>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetVoteGroupsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<VoteGroup>> Handle(GetVoteGroupsQuery request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => _unitOfWork.VoteGroups.GetAll());
        }
    }
}
