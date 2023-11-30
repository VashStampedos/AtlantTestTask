namespace AtlantTest.DB.Entities
{
    public class Storekeeper
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public IEnumerable<Detail> Details{ get; set; }
    }
}
