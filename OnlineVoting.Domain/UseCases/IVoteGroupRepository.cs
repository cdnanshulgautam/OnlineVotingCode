using OnlineVoting.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Domain.UseCases
{
    public interface IVoteGroupRepository: IRepository<VoteGroup>
    {
    }
}
