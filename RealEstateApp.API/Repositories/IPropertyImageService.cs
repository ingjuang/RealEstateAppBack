using RealEstateApp.API.Models;
using RealEstateApp.API.Shared.Response;
using System.Threading.Tasks;

namespace RealEstateApp.API.Repositories
{
    public interface IOwnerService
    {
        public Task<PetitionResponse> Get();
        public Task<PetitionResponse> GetByID(int IdOwner);
        public Task<PetitionResponse> Add(Owner owner);
        public Task<PetitionResponse> Update(Owner owner);
        public Task<PetitionResponse> Delete(int IdOwner);
    }
}
