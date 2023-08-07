namespace WebApplication2.Models
{
    public class StoreLocation
    {
        public Guid StoreNumber { get; set; }
        
        private string _Name;

        public string Name
        {
            get => _Name;
            set
            {
                if(string.IsNullOrEmpty(value) || value.Length < 30)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));

                }
                _Name = value;
            }
        }

        private string _Address;

        public string Address
        {
            get => _Address;
            set
            {
                if(string.IsNullOrEmpty(value) || value.Length < 50 )
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                _Address = value;
            }
        }

        public HashSet<LaptopStore> laptopStores { get; set; } = new HashSet<LaptopStore>();
    }
}
