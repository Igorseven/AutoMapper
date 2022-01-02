namespace AutoMapper.Business.Request
{
    public class VehicleRequest
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public string VehicleDetails { get; set; }
        public ManufacturerRequest Manufacturer { get; set; }
        public decimal Price { get; set; }
    }
}
