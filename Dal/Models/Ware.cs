using System;

namespace Dal.Models
{
    public class Ware
    {
        public int WareId { get; private set; }
        public string SerialNumber { get; private set; }
        public int ProductTypeId { get; private set; }
        public ProductType ProductType { get; private set; }
        public int LocationId { get; private set; }
        public Location Location { get; private set; }


        private Ware()
        {

        }

        public Ware(string serialNumber, ProductType productType, Location location)
        {
            SerialNumber = serialNumber;
            ProductType = productType;
            Location = location;
        }
        
        public void UpdateSerialNumber(string serialNumber)
        {
            if (string.IsNullOrWhiteSpace(serialNumber))
            {
                throw new ArgumentNullException(nameof(serialNumber), "Cannot be null or empty");
            }

            SerialNumber = serialNumber;
        }

        public void UpdateLocation(Location location)
        {
            if(location == null)
            {
                throw new ArgumentNullException(nameof(location), "Cannot be null or empty");
            }

            Location = location;
        }

    }
}
