using System;
using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuggyController : BaseController
    {
        private readonly PortalContext _context;
        public BuggyController(PortalContext context)
        {
            _context = context;
 
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var thing = _context.Products.Find(Guid.NewGuid());
            if(thing == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }
 
        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var thing = _context.Products.Find(Guid.NewGuid());
            var thingToReturn = thing.ToString();
 
            return Ok();
        }
 
        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }
 
        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }

    }
}