using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BugTrackingApiDotNet.Data;
using BugTrackingApiDotNet.Models;
using BugTrackingApiDotNet.DTOs;

namespace BugTrackingApiDotNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BugsController : ControllerBase
    {
        private readonly BugDbContext _context;

        public BugsController(BugDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bug>>> GetAllBugs()
        {
            var bugs = await _context.Bugs.OrderByDescending(b => b.Id).ToListAsync();
            return Ok(bugs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bug>> GetBugById(int id)
        {
            var bug = await _context.Bugs.FindAsync(id);

            if (bug == null)
            {
                return NotFound(new { message = "Bug not found" });
            }

            return Ok(bug);
        }

        [HttpPost]
        public async Task<ActionResult<Bug>> CreateBug(CreateBugDto dto)
        {
            var validPriorities = new[] { "low", "medium", "high" };

            if (string.IsNullOrWhiteSpace(dto.Title))
            {
                return BadRequest(new { message = "Title is required" });
            }

            if (!validPriorities.Contains(dto.Priority.ToLower()))
            {
                return BadRequest(new { message = "Priority must be low, medium, or high" });
            }

            var bug = new Bug
            {
                Title = dto.Title.Trim(),
                Description = dto.Description?.Trim() ?? "",
                Priority = dto.Priority.ToLower(),
                Status = "open"
            };

            _context.Bugs.Add(bug);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBugById), new { id = bug.Id }, bug);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Bug>> UpdateBug(int id, UpdateBugDto dto)
        {
            var bug = await _context.Bugs.FindAsync(id);

            if (bug == null)
            {
                return NotFound(new { message = "Bug not found" });
            }

            var validPriorities = new[] { "low", "medium", "high" };
            var validStatuses = new[] { "open", "in-progress", "closed" };

            if (dto.Title != null)
            {
                if (string.IsNullOrWhiteSpace(dto.Title))
                {
                    return BadRequest(new { message = "Title cannot be empty" });
                }

                bug.Title = dto.Title.Trim();
            }

            if (dto.Description != null)
            {
                bug.Description = dto.Description.Trim();
            }

            if (dto.Priority != null)
            {
                if (!validPriorities.Contains(dto.Priority.ToLower()))
                {
                    return BadRequest(new { message = "Priority must be low, medium, or high" });
                }

                bug.Priority = dto.Priority.ToLower();
            }

            if (dto.Status != null)
            {
                if (!validStatuses.Contains(dto.Status.ToLower()))
                {
                    return BadRequest(new { message = "Status must be open, in-progress, or closed" });
                }

                bug.Status = dto.Status.ToLower();
            }

            await _context.SaveChangesAsync();

            return Ok(bug);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBug(int id)
        {
            var bug = await _context.Bugs.FindAsync(id);

            if (bug == null)
            {
                return NotFound(new { message = "Bug not found" });
            }

            _context.Bugs.Remove(bug);
            await _context.SaveChangesAsync();

            return Ok(new { message = $"Bug {id} deleted successfully" });
        }
    }
}