using OnlineVoting.Domain.Entities;
using OnlineVoting.Domain.UseCases;
using OnlineVoting.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Infrastructure.Implementations
{
    public class VoteGroupRepository : Repository<VoteGroup>,IVoteGroupRepository
    {
        public VoteGroupRepository(VotingContext context) : base(context)
        {
            
        }
    }
}
