using _72HourProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace _72HourProject.Controllers
{
    //create post
    public class PostController : ApiController
    {
        private readonly UserDbContext _context = new UserDbContext();
        public async Task<IHttpActionResult> CreatePost([FromBody] Post model)
        {
            if (model is null)
            {
                return BadRequest("Your request body cannot be empty");
            }

            if (ModelState.IsValid)
            {
                _context.Posts.Add(model);
                int changeCount = await _context.SaveChangesAsync();
                return Ok("Post was created!");
            }

            return BadRequest(ModelState);
        }

        //get all post
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<Post> posts = await _context.Posts.ToListAsync();
            return Ok();
        }
    }
}
