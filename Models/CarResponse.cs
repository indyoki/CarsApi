namespace CarsApi.Models
{
    public class CarResponse
    {
        public List<Car>? cars { get; set; }
        public int page_number { get; set; }
        public int number_of_pages { get; set; }
        public int per_page { get; set; }
    }
}
