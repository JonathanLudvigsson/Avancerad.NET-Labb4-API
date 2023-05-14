using Labb4API.Services;
using Labb4Models;
using Microsoft.AspNetCore.Mvc;

namespace Labb4API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : Controller
    {
        private IRepository<Interest> _Api;

        public InterestController(IRepository<Interest> api)
        {
            _Api = api;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInterests()
        {
            //try
            //{
            return Ok(await _Api.GetAll());
            //}
            //catch (Exception)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve all Interests lmao.");
            //}
        }

        [HttpGet("{id:int}/getSingleInterest")]
        public async Task<IActionResult> GetInterest(int id)
        {
            try
            {
                return Ok(await _Api.Get(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Interest with id not found");
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddInterest(Interest InterestToAdd)
        {
            if (InterestToAdd != null)
            {
                return Ok(await _Api.Add(InterestToAdd));
            }
            return StatusCode(StatusCodes.Status406NotAcceptable, "Added Interest is not acceptable");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateInterest(int id, Interest updatedInterest)
        {
            if (updatedInterest != null)
            {
                return Ok(await _Api.Update(id, updatedInterest));
            }
            return StatusCode(StatusCodes.Status406NotAcceptable, "Updated data is not acceptable");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveInterest(int id)
        {
            return Ok(await _Api.Remove(id));
        }
    }
}
