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
    public class ReplyController : ApiController
    {
        private readonly UserDbContext _context = new UserDbContext();

        [HttpPost]
        public async Task<IHttpActionResult> CreateReply([FromBody] Reply model)
        {
            try
            {
                if (model is null)
                {
                    return BadRequest("Your request body cannot be empty!");
                }

                if (ModelState.IsValid)
                {
                    _context.Replies.Add(model);
                    await _context.SaveChangesAsync();
                    return Ok("Reply was created!");
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAllRepliesByComment([FromUri] Reply model)
        {
            List<Reply> replies = await _context.Replies.ToListAsync();
            //List<Comment> comments = await _context.Comments.ToListAsync();

            try
            {
                if (replies is null)
                {
                    return BadRequest("There was an error.");
                }
                if (ModelState.IsValid)
                {
                    foreach (Reply reply in _context.Replies)
                    {
                        if (reply.CommentId == model.CommentId)
                        {
                            return Ok(replies);
                        }
                    }

                }
                return BadRequest("There was an error.");
            }
            catch (Exception ex)
            {
                return BadRequest("There was an error.");
            }
        }



    }
}
