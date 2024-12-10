using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Domain.Entities
{
    public class Vote
    {
        public int VoteId { get; set; }
        public string UserId { get; set; }
        public int GroupId { get; set; }
        public DateTime VoteDate { get; set; }
        public ApplicationUser User { get; set; }
        public VoteGroup VoteGroup { get; set; }
    }
}
