using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Domain.UseCases
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IVoteRepository Votes { get; }
        IVoteGroupRepository VoteGroups { get; }
        Task<int> CompleteAsync();
    }
}
