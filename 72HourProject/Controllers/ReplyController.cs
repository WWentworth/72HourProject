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
                    //var changeCount =
                    await _context.SaveChangesAsync();
                    return Ok("Reply was created!");
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest(ModelState);
            }
            //return BadRequest(ModelState);
        }

       // [HttpGet]
        //public async T


    }
}
