using RealEstateApp.API.Models;
using RealEstateApp.API.Shared.Response;
using System.Threading.Tasks;

namespace RealEstateApp.API.Repositories
{
    public interface IPropertyImageService
    {
        public Task<PetitionResponse> Get(int idProperty);
        public Task<PetitionResponse> GetByID(int idPropertyImage);
        public Task<PetitionResponse> Add(PropertyImage propertyImage);
        public Task<PetitionResponse> Update(PropertyImage propertyImage);
        public Task<PetitionResponse> Delete(int idPropertyImage);
    }
}
