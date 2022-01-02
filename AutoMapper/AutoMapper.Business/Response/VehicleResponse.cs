namespace AutoMapper.Business.Response
{
    public class VehicleResponse
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public string VehicleDetails { get; set; }
        public ManufacturerResponse Manufacturer { get; set; }
        public decimal Price { get; set; }
    }
}
