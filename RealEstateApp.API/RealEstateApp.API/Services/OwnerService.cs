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
    public class OwnerService: IOwnerService
    {
        public async Task<PetitionResponse> Add(Owner owner)
        {
            BOOwner bOOwner = new BOOwner(owner);
            return await bOOwner.Add();
        }

        public async Task<PetitionResponse> Delete(int IdOwner)
        {
            BOOwner bOOwner = new BOOwner();
            return await bOOwner.Delete(IdOwner);
        }

        public async Task<PetitionResponse> Get()
        {
            BOOwner bOOwner = new BOOwner();
            return await bOOwner.Get();
        }

        public async Task<PetitionResponse> GetByID(int IdOwner)
        {
            BOOwner bOOwner = new BOOwner();
            return await bOOwner.GetById(IdOwner);
        }

        public async Task<PetitionResponse> Update(Owner owner)
        {
            BOOwner bOOwner = new BOOwner();
            return await bOOwner.Update(owner);
        }
    }
}
