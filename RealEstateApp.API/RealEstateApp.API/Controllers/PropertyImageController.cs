using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp.API.Models;
using RealEstateApp.API.Services;
using RealEstateApp.API.Shared.Response;
using System.Threading.Tasks;

namespace RealEstateApp.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]

    public class PropertyImageController : ControllerBase
    {
        public RealEstateAppContext _db;
        public PropertyImageService _propertyImages = new PropertyImageService();
        [HttpGet, Route("Get")]
        public async Task<ActionResult> Get(int idProperty)
        {
            PetitionResponse res = await _propertyImages.Get(idProperty);
            return Ok(res);
        }
        [HttpGet, Route("GetById")]
        public async Task<ActionResult> GetById(int IdPropertyImage)
        {
            PetitionResponse res = await _propertyImages.GetByID(IdPropertyImage);
            return Ok(res);
        }
        [HttpPost]
        public async Task<ActionResult> Post(PropertyImage propertyImage)
        {
            PetitionResponse res = await _propertyImages.Add(propertyImage);
            return Ok(res);
        }
        [HttpPut]
        public async Task<ActionResult> Put(PropertyImage propertyImage)
        {
            PetitionResponse res = await _propertyImages.Update(propertyImage);
            return Ok(res);
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int IdPropertyImage)
        {
            PetitionResponse res = await _propertyImages.Delete(IdPropertyImage);
            return Ok(res);
        }
    }
}
