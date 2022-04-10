using Microsoft.AspNetCore.Mvc;
using RealEstateApp.API.Models;
using RealEstateApp.API.Services;
using RealEstateApp.API.Shared.Response;
using System.Threading.Tasks;

namespace RealEstateApp.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        public RealEstateAppContext _db;
        public PropertyService _properties = new PropertyService();
        [HttpGet, Route("Get")]
        public async Task<ActionResult> Get()
        {
            PetitionResponse res = await _properties.Get();
            return Ok(res);
        }
        [HttpGet, Route("GetById")]
        public async Task<ActionResult> GetById(int IdProperty)
        {
            PetitionResponse res = await _properties.GetByID(IdProperty);
            return Ok(res);
        }
        [HttpPost]
        public async Task<ActionResult> Post(Property property)
        {
            PetitionResponse res = await _properties.Add(property);
            return Ok(res);
        }
        [HttpPut]
        public async Task<ActionResult> Put(Property property)
        {
            PetitionResponse res = await _properties.Update(property);
            return Ok(res);
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int IdProperty)
        {
            PetitionResponse res = await _properties.Delete(IdProperty);
            return Ok(res);
        }
    }
}
