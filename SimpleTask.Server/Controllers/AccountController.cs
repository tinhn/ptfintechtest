using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleTask.Server.Data;
using SimpleTask.Server.Models;

namespace SimpleTask.Server.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SimpleTaskDbContext _db;
        public AccountController(SimpleTaskDbContext context)
        {
            _db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        {
            return await _db.People.ToListAsync();
        }

        [HttpGet("myprofile")]
        public async Task<ActionResult<ResponseResult>> GetAccount(int id)
        {
            var account = await _db.People.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            var result = new ResponseResult { success = true, user=account };
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ResponseResult>> AccountLogin(AccountLogin login)
        {
            var account = await _db.People
                .Where(c => (c.Username == login.Username && c.Password == login.Password))
                .FirstOrDefaultAsync();

            if (account == null)
            {
                return NotFound("Invalid user");
            }           

            var result = new ResponseResult { success= true,message= "Welcome back "+login.Username };
            return Ok(result);
        }

        [HttpGet("logout")]
        public async Task<ActionResult<ResponseResult>> AccountLogout()
        {
            var result = new ResponseResult { success = true, message = "Logout succussfully" };
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<ActionResult<Account>> RegAccount(Account account)
        {
            if (String.IsNullOrEmpty(account.Email) & EmailExists(account.Email))
            {
                return BadRequest("Email not emplty or already exists.");
            }
            else if (String.IsNullOrEmpty(account.Username) & UsernameExists(account.Username))
            {
                return BadRequest("Username not available.");
            }
            else
            {
                _db.People.Add(account);
                await _db.SaveChangesAsync();
                return Ok(account);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Account>> PutTask(int id, Account account)
        {
            if (id != account.Id)
            {
                return BadRequest();
            }

            _db.Entry(account).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.TaskInfos.Any(e => e.Id == id))
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

        private bool UsernameExists(string username)
        {
            return _db.People.Any(e => e.Username == username);
        }

        private bool EmailExists(string email)
        {
            return _db.People.Any(e => e.Email == email);
        }
    }
}
