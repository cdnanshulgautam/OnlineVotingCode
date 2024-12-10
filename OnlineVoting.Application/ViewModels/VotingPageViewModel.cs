using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Application.ViewModels
{
    public class VotingPageViewModel
    {
        public IEnumerable<VoteViewModel> VoteGroups { get; set; }
        public bool UserHasVoted { get; set; }
    }
}
