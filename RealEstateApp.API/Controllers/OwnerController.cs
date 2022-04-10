using Microsoft.AspNetCore.Mvc;
using RealEstateApp.API.Models;
using RealEstateApp.API.Services;
using RealEstateApp.API.Shared.Response;
using System.Threading.Tasks;

namespace RealEstateApp.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        public RealEstateAppContext _db;
        public OwnerService _owners = new OwnerService();
        [HttpGet, Route("Get")]
        public async Task<ActionResult> Get()
        {
            PetitionResponse res = await _owners.Get();
            return Ok(res);
        }
        [HttpGet, Route("GetById")]
        public async Task<ActionResult> GetById(int IdOwner)
        {
            PetitionResponse res = await _owners.GetByID(IdOwner);
            return Ok(res);
        }
        [HttpPost]
        public async Task<ActionResult> Post(Owner owner)
        {
            PetitionResponse res = await _owners.Add(owner);
            return Ok(res);
        }
        [HttpPut]
        public async Task<ActionResult> Put(Owner owner)
        {
            PetitionResponse res = await _owners.Update(owner);
            return Ok(res);
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int IdOwner)
        {
            PetitionResponse res = await _owners.Delete(IdOwner);
            return Ok(res);
        }
    }
}
