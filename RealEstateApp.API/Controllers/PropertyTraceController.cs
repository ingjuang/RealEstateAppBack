using Microsoft.AspNetCore.Mvc;
using RealEstateApp.API.Models;
using RealEstateApp.API.Services;
using RealEstateApp.API.Shared.Response;
using System.Threading.Tasks;

namespace RealEstateApp.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PropertyTraceController : ControllerBase
    {
        public RealEstateAppContext _db;
        public PropertyTraceService _propertyTraces = new PropertyTraceService();
        [HttpGet, Route("Get")]
        public async Task<ActionResult> Get()
        {
            PetitionResponse res = await _propertyTraces.Get();
            return Ok(res);
        }
        [HttpGet, Route("GetById")]
        public async Task<ActionResult> GetById(int IdPropertyTrace)
        {
            PetitionResponse res = await _propertyTraces.GetByID(IdPropertyTrace);
            return Ok(res);
        }
        [HttpPost]
        public async Task<ActionResult> Post(PropertyTrace propertyTrace)
        {
            PetitionResponse res = await _propertyTraces.Add(propertyTrace);
            return Ok(res);
        }
        [HttpPut]
        public async Task<ActionResult> Put(PropertyTrace propertyTrace)
        {
            PetitionResponse res = await _propertyTraces.Update(propertyTrace);
            return Ok(res);
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int IdPropertyTrace)
        {
            PetitionResponse res = await _propertyTraces.Delete(IdPropertyTrace);
            return Ok(res);
        }
    }
}
