using AtlantTest.DB;
using AtlantTest.DB.Entities;
using AtlantTest.Domain.Exceptions;
using AtlantTest.Domain.Services.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;

namespace AtlantTest.Domain.Services.DetailService
{
    public class DetailService: ApplicatiobDbContextService,IDetailService
    {
        public DetailService(StoreApplicationContext context):base(context)
        {
            
        }

        public async Task<IEnumerable<Detail>> GetDetailsAsync()
        {
            var details = await context.Details.AsNoTracking().Include(x=> x.Storekeeper).ToListAsync();
            return details;
        }
        public async Task<Detail> GetDetailAsync(int id)
        {
            var detail = await context.Details.FirstOrDefaultAsync(x => x.Id == id);
            _ = detail ?? throw new NotFoundException("Detail Not Found");
            return detail;
        }
        public async Task CreateDetailAsync(string nomenclCode, string detailName, int storeKeeperId, string dateOfCreation, int count = 0)
        {
            await CheckDetailExist(nomenclCode, detailName);
            var newDetail = new Detail()
            {
                NomenclCode = nomenclCode,
                DetailName = detailName,
                StorekeeperId = storeKeeperId,
                DateOfCreation = DateTime.Parse(dateOfCreation),
                DetailCount = count
            };
            await context.AddAsync(newDetail);
            await SaveChangesAsync();
        }
        public async Task UpdateDetailAsync(int id, string nomenclCode, string detailName, int storeKeeperId, string dateOfCreation, int count = 0)
        {
            await CheckDetailExist(nomenclCode, detailName);
            var updatedDetail = await GetDetailAsync(id);
            context.Update(updatedDetail);
            await SaveChangesAsync();
        }
        public async Task DeleteDetailAsync(int id, string dateOfRemoving)
        {
            var deletedDetail = await GetDetailAsync(id);
            deletedDetail.DateOfRemoving = DateTime.Parse(dateOfRemoving);
            context.Update(deletedDetail);
            await SaveChangesAsync();
        }

        private async Task CheckDetailExist(string nomenclCode, string detailName)
        {
            var isExistsDetail = await context.Details.AsNoTracking().AnyAsync(x => x.NomenclCode == nomenclCode && x.DetailName == detailName);
            if (isExistsDetail)
                throw new ConflictException($"Detail is already exists");
        }
    }
}
