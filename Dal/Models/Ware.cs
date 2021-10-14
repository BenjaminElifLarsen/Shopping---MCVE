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
        { //check for nulls
            SerialNumber = serialNumber;
            ProductType = productType;
            Location = location;
        }

        public Ware(int id, string serialNumber, ProductType productType, Location location)
        { //dont check for nulls as this one is used to create update entity. Perhaps have a class or record version for updating
            WareId = id;
            SerialNumber = serialNumber;
            ProductType = productType;
            Location = location;
        }

        internal void UpdateSerialNumber(string serialNumber)
        {
            if (string.IsNullOrWhiteSpace(serialNumber))
            {
                throw new ArgumentNullException(nameof(serialNumber), "Cannot be null or empty");
            }

            SerialNumber = serialNumber;
        }

        internal void UpdateLocation(Location location)
        {
            if(location == null)
            {
                throw new ArgumentNullException(nameof(location), "Cannot be null or empty");
            }

            Location = location;
        }

    }
}
