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
    public class CommentController : ApiController
    {
        private readonly UserDbContext _context = new UserDbContext();
        //Post a comment
        [HttpPost]
        public async Task<IHttpActionResult> PostComment ([FromBody] Comment model)
        {
            try 
            {

                if (model is null)
                {
                    return BadRequest("Your comment body cannot be empty.");
                }
                if (ModelState.IsValid)
                {
                    _context.Comments.Add(model);
                    int changeXount = await _context.SaveChangesAsync();
                    return Ok("Comment was successfully posted");
                }

                //If comment is invalid
                return BadRequest(ModelState);
            }

            catch (Exception ex)
            {
                return BadRequest(ModelState);
            }

        }

        //Get Comments by Post Id
        // api/Comment/{id}
        [HttpGet]
        public async Task<IHttpActionResult> GetAllCommentsByPost([FromUri] Comment model)
        {
            try
            {

                List<Comment> comments = await _context.Comments.ToListAsync();

                if (model is null)
                {
                    return BadRequest("There was an error.");
                }

                if (ModelState.IsValid)
                {
                    foreach (Comment c in _context.Comments)
                    {
                        if (c.PostId == model.PostId)
                        {
                            return Ok(model);
                        }
                    }
                }

                return BadRequest("There was an error.");
            }

            catch (Exception ex)
            {
                return BadRequest(ModelState);
            }
        }
    }
}
