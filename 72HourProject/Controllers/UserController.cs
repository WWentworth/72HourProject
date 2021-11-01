using _72HourProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace _72HourProject.Controllers
{
    public class UserController : ApiController
    {
        private readonly UserDbContext _context = new UserDbContext();
        [HttpPost]
        public async Task<IHttpActionResult> CreateUser
            ([FromBody] User model)
        {
            if (model is null)
            {
                return BadRequest("Your request body cannot be empty!");
            }
            if (ModelState.IsValid)
            {
                _context.Users.Add(model);
                int changeCount = await _context.SaveChangesAsync();
                return Ok("User was created!");
            }
            return BadRequest(ModelState);
        }


        [HttpGet]
        public async Task<IHttpActionResult> GetById([FromUri] int id)
        {
            User user = await
                _context.Users.FindAsync(id);

            if (user != null)
            {
                return Ok(user);
            }
                return NotFound();
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateUser
            ([FromUri] int id, [FromBody] User updatedUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            User user = await _context.Users.FindAsync(id);

            if (user is null)
                return NotFound();

            user.UserName = updatedUser.UserName;

            await _context.SaveChangesAsync();
            return Ok("The User was updated!");
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteUser
        ([FromUri] int id)
        {
            User user = await _context.Users.FindAsync(id);

            if (user is null)
                return NotFound();

            _context.Users.Remove(user);
            if(await _context.SaveChangesAsync() == 1)
            {
                return Ok("The user was deleted!");
            }
            return InternalServerError();
        }
        
    }
}
