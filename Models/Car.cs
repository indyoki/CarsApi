namespace CarsApi.Models
{
    public class Car
    {
        public virtual int Id { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public int year { get; set; }
        public string color { get; set; }
        public double price { get; set; }
    }
}