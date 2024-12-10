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
    public class VoteRepository : Repository<Vote>, IVoteRepository
    {
        public VoteRepository(VotingContext context) : base(context)
        {
            
        }

        public IEnumerable<Vote> GetVotesByUserId(string userId)
        {
            return _context.Votes.Where(v => v.UserId == userId).ToList();
        }
    }
}
