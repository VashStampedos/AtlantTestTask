using AtlantTest.DB;
using AtlantTest.Domain.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AtlantTest.Domain.Services.Context
{
    public class ApplicatiobDbContextService
    {
        public readonly StoreApplicationContext context;

        public ApplicatiobDbContextService(StoreApplicationContext context)
        {
            this.context = context;
        }

        public async Task SaveChangesAsync()
        {
            int result;
            try
            {
                result = await context.SaveChangesAsync();
            }catch (Exception ex)
            {
                throw new ConflictException("Can't save changes to database", ex);
            }
            if(result<1)
                throw new ConflictException("Changes don't saved");
        }
    }
}
