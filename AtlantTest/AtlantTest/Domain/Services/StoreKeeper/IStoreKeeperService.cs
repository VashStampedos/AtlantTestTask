using AtlantTest.DB.Entities;

namespace AtlantTest.Domain.Services.StoreKeeper
{
    public interface IStoreKeeperService
    {
        public Task<IEnumerable<Storekeeper>> GetStoreKeepers();
        public Task<Storekeeper> GetStoreKeeper(int id);
        public Task CreateStoreKeeper(string fio);
        public Task UpdateStoreKeeper(int id, string fio);
        public Task DeleteStoreKeeper(int id);
    }
}
