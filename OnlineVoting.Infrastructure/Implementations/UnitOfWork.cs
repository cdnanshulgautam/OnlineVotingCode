using OnlineVoting.Domain.UseCases;
using OnlineVoting.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Infrastructure.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VotingContext _context;

        public UnitOfWork(VotingContext context)
        {
            _context = context;
            Users = new UserRespository(_context);
            Votes = new VoteRepository(_context);
            VoteGroups = new VoteGroupRepository(_context);
        }
        public IUserRepository Users { get; private set; }

        public IVoteRepository Votes { get; private set; }
        public IVoteGroupRepository VoteGroups { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async void Dispose()
        {
            _context.Dispose();
        }
    }
}
