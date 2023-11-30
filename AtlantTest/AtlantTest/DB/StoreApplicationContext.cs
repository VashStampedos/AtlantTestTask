using AtlantTest.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace AtlantTest.DB
{
    public class StoreApplicationContext:DbContext
    {
        public DbSet<Storekeeper> Storekeepers { get; set; }
        public DbSet<Detail> Details { get; set; }
        public StoreApplicationContext(DbContextOptions<StoreApplicationContext> options):base(options)
        {   
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Storekeeper>(entity =>
            {
                entity.ToTable("StoreKeepers");
                entity.Property(x=> x.Id).IsRequired();
                entity.HasKey(x => x.Id);
                entity.Property(x=> x.FIO).IsRequired();
              

            });

            modelBuilder.Entity<Detail>(entity =>
            {
                entity.ToTable("Details");
                entity.Property(x => x.Id).IsRequired();
                entity.HasKey(x => x.Id);
                entity.Property(x=> x.NomenclCode).IsRequired();
                entity.Property(x => x.DetailName).IsRequired();
                entity.Property(x => x.DetailCount);
                entity.Property(x => x.StorekeeperId).IsRequired();
                entity.Property(x => x.DateOfCreation).HasColumnType("date").IsRequired();
                entity.Property(x => x.DateOfRemoving).HasColumnType("date");
                entity.HasOne(x => x.Storekeeper).WithMany(x => x.Details).HasForeignKey(x => x.StorekeeperId).OnDelete(DeleteBehavior.Cascade);
            });


        }



    }
}
