using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Domain.Entities
{
    public class VoteGroup
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
        public string Symbol { get; set; }
        public int VotesCount { get; set; }
        public ICollection<Vote> Votes { get; set; } 
    }
}
