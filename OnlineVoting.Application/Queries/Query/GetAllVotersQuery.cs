using MediatR;
using OnlineVoting.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Application.Queries.Query
{
    public class GetAllVotersQuery : IRequest<IEnumerable<VoterViewModel>>
    {
    }
}
