using AtlantTest.DB;
using AtlantTest.DB.Entities;
using AtlantTest.Domain.Exceptions;
using AtlantTest.Domain.Services.Context;
using Microsoft.EntityFrameworkCore;

namespace AtlantTest.Domain.Services.StoreKeeper
{
    public class StoreKeeperService:ApplicatiobDbContextService,IStoreKeeperService
    {

        public StoreKeeperService(StoreApplicationContext context):base(context)
        {
        }


        public async Task<IEnumerable<Storekeeper>> GetStoreKeepers()
        {
            var storeKeepers = await context.Storekeepers.AsNoTracking().Include(x=> x.Details).ToListAsync();
            return storeKeepers;
        }
        public async Task<Storekeeper> GetStoreKeeper(int id)
        {
            var storeKeeper = await context.Storekeepers.Include(x=> x.Details).FirstOrDefaultAsync(x=> x.Id == id);
            _ = storeKeeper ?? throw new NotFoundException("Storekeeper Not Found");
            return storeKeeper;
        }

        public async Task CreateStoreKeeper(string fio)
        {
            await CheckStoreKeeperFIOAsync(fio);
            var newStoreKeeper = new Storekeeper()
            {
                FIO = fio,
            };

            await context.AddAsync(newStoreKeeper);
            await SaveChangesAsync();

        }
        public async Task UpdateStoreKeeper(int id, string fio)
        {
            await CheckStoreKeeperFIOAsync(fio);
            var updateStoreKeeper = await GetStoreKeeper(id);
            updateStoreKeeper.FIO = fio;
            context.Update(updateStoreKeeper);
            await SaveChangesAsync();

        }
        public async Task DeleteStoreKeeper(int id)
        {
            var deletedStoreKeeper = await GetStoreKeeper(id);
            if(deletedStoreKeeper.Details.Count() <= 0 || deletedStoreKeeper.Details == null)
            {
                context.Remove(deletedStoreKeeper);
                await SaveChangesAsync();

            }
            else
            {
                throw new ConflictException("StoreKeeper have details");
            }
        }
        private async Task CheckStoreKeeperFIOAsync(string fio)
        {
            var isExistsStoreKeeper =await context.Storekeepers.AsNoTracking().AnyAsync(x=> x.FIO == fio);
            if(isExistsStoreKeeper)
                throw new ConflictException($"Storekeeper with FIO: {fio} is already exists");
        }
    }
}
