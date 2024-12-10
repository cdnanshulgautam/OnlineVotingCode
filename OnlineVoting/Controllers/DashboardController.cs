using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineVoting.Application.Commands.Command;
using OnlineVoting.Application.Queries.Query;

namespace OnlineVoting.Web.Controllers
{
    [Authorize(Roles ="Admin")]
    public class DashboardController : Controller
    {
        private readonly IMediator _mediator;
        public DashboardController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> AllVoters()
        {
            var voters = await _mediator.Send(new GetAllVotersQuery());
            return View(voters);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAuthorization(string userId, bool isAuthorized)
        {
            var command = new UpdateVoterAuthorizationCommand { UserId = userId, IsAuthorized = isAuthorized };
            var result = await _mediator.Send(command);
            if (result)
            {
                return RedirectToAction("AllVoters");
            }
            TempData["ErrorMessage"] = "Failed to update authorization status";
            return RedirectToAction("AllVoters");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LockVoter(string userId, bool lockUser)
        {
            var command = new LockVoterCommand { UserId = userId, Lock = lockUser };
            var result = await _mediator.Send(command);
            if (result)
            {
                return RedirectToAction("AllVoters");
            }
            TempData["ErrorMessage"] = "Failed to update lock status";
            return RedirectToAction("AllVoters");
        }
    }
}
