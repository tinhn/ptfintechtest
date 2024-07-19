using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleTask.Server.Data;
using SimpleTask.Server.Models;

namespace SimpleTask.Server.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly SimpleTaskDbContext _db;
        public TaskController(SimpleTaskDbContext context)
        {
            _db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountTask>>> GetTasks()
        {
            return await _db.TaskInfos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountTask>> GetTask(int id)
        {
            var task = await _db.TaskInfos.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpGet("getTask")]
        public async Task<ActionResult<ResponseResult>> GetTaskByAccount(string username)
        {
            var task_lt = await _db.TaskInfos
                .Where(c => c.CreatedBy == username)
                .ToListAsync();

            if (task_lt == null)
            {
                return NotFound();
            }
            
            var result = new ResponseResult { success = true, userTasks= task_lt};
            return Ok(result);
        }

        [HttpPost("addTask")]
        public async Task<ActionResult<AccountTask>> PostTask(AccountTask accountTask)
        {
            if (!String.IsNullOrEmpty(accountTask.Title))
            {
                accountTask.CreatedAt = DateOnly.FromDateTime(DateTime.Now);
                accountTask.StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1));
                accountTask.DueDate = DateOnly.FromDateTime(DateTime.Now.AddDays(14));
                accountTask.TaskStatus = "To-Do";

                _db.TaskInfos.Add(accountTask);
                await _db.SaveChangesAsync();

                return Ok(accountTask);
            }
            else
                return BadRequest("Title is empty.");
        }

        [HttpPut]
        public async Task<ActionResult<AccountTask>> PutTask(int id, AccountTask accountTask)
        {
            if (id != accountTask.Id)
            {
                return BadRequest();
            }

            _db.Entry(accountTask).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _db.TaskInfos.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            _db.TaskInfos.Remove(task);
            await _db.SaveChangesAsync();

            var result = new ResponseResult { success = true, message="Tast removed." };

            return Ok(result);
        }

        private bool TaskExists(int id)
        {
            return _db.TaskInfos.Any(e => e.Id == id);
        }
    }
}
