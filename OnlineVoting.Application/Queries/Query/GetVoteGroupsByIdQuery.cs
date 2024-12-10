using MediatR;
using OnlineVoting.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Application.Queries.Query
{
    public class GetVoteGroupsByIdQuery :IRequest<VoteGroup>
    {
        public int GroupId { get; set; }
    }
}
