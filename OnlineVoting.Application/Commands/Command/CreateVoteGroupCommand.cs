using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Application.Commands.Command
{
    public class CreateVoteGroupCommand : IRequest<bool>
    {
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
        public string GroupImageUrl { get; set; }
    }
}
