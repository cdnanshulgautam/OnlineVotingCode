using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Application.Commands.Command
{
    public class LockVoterCommand : IRequest<bool>
    {
        public string UserId { get; set; }
        public bool Lock { get; set; }
    }
}
