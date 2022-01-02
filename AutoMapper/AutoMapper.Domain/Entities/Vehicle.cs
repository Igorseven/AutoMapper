namespace AutoMapper.Domain.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public string VehicleDetails { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public decimal Price { get; set; }

    }
}
