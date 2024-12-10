using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Application.Commands.Command
{
    public class CastVoteCommand : IRequest<bool>
    {
        public int GroupId { get; set; }
        public string UserId { get; set; }
    }
}
