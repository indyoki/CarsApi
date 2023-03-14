namespace CarsApi.Models
{
    public class UpdateRequest
    {
        public int Id { get; set; }
        public string? color { get; set; }
        public double price { get; set; }
    }
}
