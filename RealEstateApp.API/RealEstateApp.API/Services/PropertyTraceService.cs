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
    public class PropertyTraceService
    {
        public async Task<PetitionResponse> Add(PropertyTrace propertyTrace)
        {
            BOPropertyTrace bOPropertyTrace = new BOPropertyTrace(propertyTrace);
            return await bOPropertyTrace.Add();
        }

        public async Task<PetitionResponse> Delete(int IdPropertyTrace)
        {
            BOPropertyTrace bOPropertyTrace = new BOPropertyTrace();
            return await bOPropertyTrace.Delete(IdPropertyTrace);
        }

        public async Task<PetitionResponse> Get()
        {
            BOPropertyTrace bOPropertyTrace = new BOPropertyTrace();
            return await bOPropertyTrace.Get();
        }

        public async Task<PetitionResponse> GetByID(int IdPropertyTrace)
        {
            BOPropertyTrace bOPropertyTrace = new BOPropertyTrace();
            return await bOPropertyTrace.GetById(IdPropertyTrace);
        }

        public async Task<PetitionResponse> Update(PropertyTrace propertyTrace)
        {
            BOPropertyTrace bOPropertyTrace = new BOPropertyTrace();
            return await bOPropertyTrace.Update(propertyTrace);
        }
    }
}
