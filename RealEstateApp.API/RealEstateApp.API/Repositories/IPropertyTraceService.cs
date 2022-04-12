using RealEstateApp.API.Models;
using RealEstateApp.API.Shared.Response;
using System.Threading.Tasks;

namespace RealEstateApp.API.Repositories
{
    public interface IPropertyTraceService
    {
        public Task<PetitionResponse> Get();
        public Task<PetitionResponse> GetByID(int IdPropertyTrace);
        public Task<PetitionResponse> Add(PropertyTrace propertyTrace);
        public Task<PetitionResponse> Update(PropertyTrace propertyTrace);
        public Task<PetitionResponse> Delete(int IdPropertyTrace);
    }
}
