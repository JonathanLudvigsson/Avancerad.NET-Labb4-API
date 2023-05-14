using Labb4API.Services;
using Labb4Models;
using Microsoft.AspNetCore.Mvc;

namespace Labb4API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        private IPersonRepo _Api;
        private IRepository<Interest> _interestApi;
        private ILinkRepo _linkApi;

        public PersonController(IPersonRepo api, IRepository<Interest> interestapi, ILinkRepo linkapi)
        {
            _Api = api;
            _interestApi = interestapi;
            _linkApi = linkapi;
        }

        [HttpGet("getAllPersons")]
        public async Task<IActionResult> GetAllPersons()
        {
            //try
            //{
            return Ok(await _Api.GetAll());
            //}
            //catch (Exception)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve all Persons lmao.");
            //}
        }

        [HttpGet("{id:int}/getSinglePerson")]
        public async Task<IActionResult> GetPerson(int id)
        {
            try
            {
                return Ok(await _Api.Get(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Person with id not found");
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddPerson(Person personToAdd)
        {
            if (personToAdd != null)
            {
                return Ok(await _Api.Add(personToAdd));
            }
            return StatusCode(StatusCodes.Status406NotAcceptable, "Added Person is not acceptable");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePerson(int id, Person updatedPerson)
        {
            if (updatedPerson != null)
            {
                return Ok(await _Api.Update(id, updatedPerson));
            }
            return StatusCode(StatusCodes.Status406NotAcceptable, "Updated data is not acceptable");
        }
        [HttpDelete]
        public async Task<IActionResult> RemovePerson(int id)
        {
            return Ok(await _Api.Remove(id));
        }

        [HttpPut("{personid:int}/addInterest/{interestid:int}")]
        public async Task<IActionResult> AddInterest(int personid, int interestid)
        {
            return Ok(await _Api.AddInterest(personid, interestid));
        }

        [HttpDelete("{personid:int}/deleteInterest/{interestid:int}")]
        public async Task<IActionResult> DeleteInterest(int personid, int interestid)
        {
            return Ok(await _Api.DeleteInterest(personid, interestid));
        }

        [HttpGet("{personid:int}/getPersonInterests")]
        public async Task<IActionResult> GetInterests(int personid)
        {
            return Ok(await _Api.GetInterests(personid));
        }

        [HttpGet("{personid:int}/getPersonLinks")]
        public async Task<IActionResult> GetPersonLinks(int personid)
        {
            return Ok(await _linkApi.GetPersonLinks(personid));
        }

        [HttpPost("{personid:int}/addLink/{url}/toInterest/{interestid:int}")]
        public async Task<IActionResult> AddLinkToInterest(int personid, string url, int interestid)
        {
            Link link = new Link()
            {
                URL = "https://" + url,
                PersonID = personid,
                InterestID = interestid
            };

            return Ok(await _linkApi.Add(link));
        }
    }
}
