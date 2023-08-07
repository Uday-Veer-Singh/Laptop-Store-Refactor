namespace WebApplication2.Models
{
    public class LaptopStore
    {
        public Guid LaptopStoreId { get; set; }
        public Laptop laptop { get; set; }
        public Guid LaptopNumber { get; set; }
        public StoreLocation StoreLocation { get; set; }
        public Guid StoreNumber { get; set;}

    }
}
