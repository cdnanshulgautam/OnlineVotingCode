using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineVoting.Application.Commands.Command;
using OnlineVoting.Application.Queries.Query;

namespace OnlineVoting.Web.Controllers
{
    [Authorize(Roles ="Admin")]
    public class VoteGroupController : Controller
    {
        private readonly IMediator _mediator;
        public VoteGroupController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var voteGroup = await _mediator.Send(new GetVoteGroupsQuery());
            return View(voteGroup);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var voteGroup = await _mediator.Send(new GetVoteGroupsByIdQuery { GroupId = id });
            if (voteGroup == null)
            {
                return NotFound();
            }
            return View(voteGroup);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateVoteGroupCommand command)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(command);
                if (result)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(command);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var voteGroup = await _mediator.Send(new GetVoteGroupsByIdQuery { GroupId = id });
            if (voteGroup == null)
            {
                return NotFound();
            }
            var command = new UpdateVoteGroupCommand
            {
                GroupId = voteGroup.Id,
                GroupName = voteGroup.GroupName,
                GroupDescription = voteGroup.GroupDescription,
                GroupImageUrl = voteGroup.Symbol
            };
            return View(command);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateVoteGroupCommand command)
        {
            if (id != command.GroupId)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(command);
                if (result)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(command);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var voteGroup = await _mediator.Send(new GetVoteGroupsByIdQuery { GroupId = id });
            if (voteGroup == null)
            {
                return NotFound();
            }

            return View(voteGroup);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletConfirmed(int id)
        {
            var result = await _mediator.Send(new DeleteVoteGroupCommand { GroupId = id });
            return RedirectToAction("Index");
        }
    }
}
