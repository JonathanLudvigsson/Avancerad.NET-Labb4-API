using Labb4API.Services;
using Labb4Models;
using Microsoft.AspNetCore.Mvc;

namespace Labb4API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : Controller
    {
        private ILinkRepo _Api;

        public LinkController(ILinkRepo api)
        {
            _Api = api;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLinks()
        {
            //try
            //{
            return Ok(await _Api.GetAll());
            //}
            //catch (Exception)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve all Links lmao.");
            //}
        }

        [HttpGet("{id:int}/getSingleLink")]
        public async Task<IActionResult> GetLink(int id)
        {
            try
            {
                return Ok(await _Api.Get(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Link with id not found");
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddLink(Link LinkToAdd)
        {
            if (LinkToAdd != null)
            {
                return Ok(await _Api.Add(LinkToAdd));
            }
            return StatusCode(StatusCodes.Status406NotAcceptable, "Added Link is not acceptable");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLink(int id, Link updatedLink)
        {
            if (updatedLink != null)
            {
                return Ok(await _Api.Update(id, updatedLink));
            }
            return StatusCode(StatusCodes.Status406NotAcceptable, "Updated data is not acceptable");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveLink(int id)
        {
            return Ok(await _Api.Remove(id));
        }

        //[HttpGet("{personid:int}/getPersonLinks")]
        //public async Task<IActionResult> GetPersonLinks(int personid)
        //{
        //    return Ok(await _Api.GetPersonLinks(personid));
        //}
    }
}
