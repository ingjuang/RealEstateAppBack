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
    public class PropertyService
    {
        public async Task<PetitionResponse> Add(Property property)
        {
            BOProperty bOProperty = new BOProperty(property);
            return await bOProperty.Add();
        }

        public async Task<PetitionResponse> Delete(int IdProperty)
        {
            BOProperty bOProperty = new BOProperty();
            return await bOProperty.Delete(IdProperty);
        }

        public async Task<PetitionResponse> Get()
        {
            BOProperty bOProperty = new BOProperty();
            return await bOProperty.Get();
        }

        public async Task<PetitionResponse> GetByID(int IdProperty)
        {
            BOProperty bOProperty = new BOProperty();
            return await bOProperty.GetById(IdProperty);
        }

        public async Task<PetitionResponse> Update(Property property)
        {
            BOProperty bOProperty = new BOProperty();
            return await bOProperty.Update(property);
        }
    }
}
