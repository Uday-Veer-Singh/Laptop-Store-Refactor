using Microsoft.Identity.Client;

namespace WebApplication2.Models
{
    public class StoreLocation
    {
        public Guid StoreNumber { get; set; }
        
        private string _StreetName;

        public string StreetName
        {
            get => _StreetName;
            set
            {
                if(string.IsNullOrEmpty(value) || value.Length < 30)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));

                }
                _StreetName = value;
            }
        }

        public int StreetNumber { get; set; } 

        public HashSet<LaptopStore> laptopStores { get; set; } = new HashSet<LaptopStore>();
        public Province Province { get; set; }
    }

    public enum Province
    {
        Manitoba,
        BritishColumbia,
        Alberta,
        Ontario
    }
}
