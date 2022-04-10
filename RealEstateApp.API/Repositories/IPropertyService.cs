using RealEstateApp.API.Models;
using RealEstateApp.API.Shared.Response;
using System.Threading.Tasks;

namespace RealEstateApp.API.Repositories
{
    public interface IPropertyService
    {
        public Task<PetitionResponse> Get();
        public Task<PetitionResponse> GetByID(int IdProperty);
        public Task<PetitionResponse> Add(Property property);
        public Task<PetitionResponse> Update(Property property);
        public Task<PetitionResponse> Delete(int IdProperty);
    }
}
