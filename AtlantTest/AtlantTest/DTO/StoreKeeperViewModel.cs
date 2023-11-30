using AtlantTest.DB.Entities;

namespace AtlantTest.DTO
{
    public class StoreKeeperViewModel
    {
        public Storekeeper Storekeeper { get; set; }
        public int CountOfDetails { get; set; }
        public StoreKeeperViewModel(Storekeeper storekeeper)
        {
            this.Storekeeper = storekeeper;
            CountOfDetails = storekeeper.Details.Count();
        }

    }
}
