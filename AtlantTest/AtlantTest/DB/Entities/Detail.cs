namespace AtlantTest.DB.Entities
{
    public class Detail
    {
        public int Id { get; set; }
        public string NomenclCode { get; set; }
        public string DetailName { get; set; }
        public int DetailCount { get; set; }
        public int StorekeeperId { get; set; }
        public DateTime DateOfCreation { get; set; }
        public System.Nullable<DateTime> DateOfRemoving { get; set; }
        public Storekeeper? Storekeeper { get; set; }
    }
}
