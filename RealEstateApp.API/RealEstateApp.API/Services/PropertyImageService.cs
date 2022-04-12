using RealEstateApp.API.Repositories;
using Microsoft.Extensions.Logging;
using RealEstateApp.API.Models;
using RealEstateApp.API.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RealEstateApp.API.Shared.Response;

namespace RealEstateApp.API.Services
{
    public class PropertyImageService: IPropertyImageService
    {
        public async Task<PetitionResponse> Add(PropertyImage propertyImage)
        {
            BOPropertyImage bOPropertyImage = new BOPropertyImage(propertyImage);
            return await bOPropertyImage.Add();
        }

        public async Task<PetitionResponse> Delete(int IdPropertyImage)
        {
            BOPropertyImage bOPropertyImage = new BOPropertyImage();
            return await bOPropertyImage.Delete(IdPropertyImage);
        }

        public async Task<PetitionResponse> Get(int idProperty)
        {
            BOPropertyImage bOPropertyImage = new BOPropertyImage();
            return await bOPropertyImage.Get(idProperty);
        }

        public async Task<PetitionResponse> GetByID(int IdPropertyImage)
        {
            BOPropertyImage bOPropertyImage = new BOPropertyImage();
            return await bOPropertyImage.GetById(IdPropertyImage);
        }

        public async Task<PetitionResponse> Update(PropertyImage propertyImage)
        {
            BOPropertyImage bOPropertyImage = new BOPropertyImage();
            return await bOPropertyImage.Update(propertyImage);
        }
    }
}
