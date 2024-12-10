using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineVoting.Application.Commands.Command;
using OnlineVoting.Application.Queries.Query;
using OnlineVoting.Domain.Entities;
using System.Security.Claims;

namespace OnlineVoting.Web.Controllers
{
    [Authorize]
    public class VotingController : Controller
    {
        private readonly IMediator _mediator;
        private readonly UserManager<ApplicationUser> _userManager;
        public VotingController(IMediator mediator, UserManager<ApplicationUser> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var query = new GetVotingGroupsQuery { UserId = userId };
            var model = await _mediator.Send(query);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Vote(int groupId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var command = new CastVoteCommand { GroupId = groupId, UserId = userId };
            var result =await _mediator.Send(command);
            if(!result)
            {
                TempData["ErrorMessage"] = "You have already voted for this group";
                return RedirectToAction("Index","Home");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
