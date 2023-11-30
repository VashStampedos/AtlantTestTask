using AtlantTest.DB.Entities;

namespace AtlantTest.Domain.Services.DetailService
{
    public interface IDetailService
    {
        
        public Task<IEnumerable<Detail>> GetDetailsAsync();
        public Task<Detail> GetDetailAsync(int id);
        public Task CreateDetailAsync(string nomenclCode, string detailName,  int storeKeeperId, string dateOfCreation,int count = 0);
        public Task UpdateDetailAsync(int id, string nomenclCode, string detailName, int storeKeeperId, string dateOfCreation, int count = 0);
        public Task DeleteDetailAsync(int id, string dateOfRemoving);
    }
}
