namespace AtlantTest.DTO.DetailRequsts
{
    public class CreateDetailRequest
    {
        public string NomenclCode { get; set; }
        public string DetailName { get; set; }
        public int DetailCount { get; set; }
        public int StorekeeperId { get; set; }
        public DateTime DateOfCreation { get; set; }
    }
}
