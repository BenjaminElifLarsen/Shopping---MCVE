using Dal.Contracts;
using Dal.Models.JoiningTables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dal.Models
{
    public class ProductType : IAggregateRoot
    {
        private HashSet<Ware> _wares;
        private HashSet<OfferProductType> _offerProductTypes;

        public int ProductTypeId { get; private set; }
        public string Type { get; private set; }
        public int Price { get; private set; }
        public int CategoryId { get; private set; }
        public Category Category { get; private set; }
        public IEnumerable<Ware> Wares { get => _wares; private set => _wares = value.ToHashSet(); }
        public IEnumerable<OfferProductType> OfferProductTypes { get => _offerProductTypes; private set => _offerProductTypes = value.ToHashSet(); } // Should not permit adding and removing.

        private ProductType()
        {

        }

        public ProductType(string type, int price, Category category, IEnumerable<Ware> wares = null, IEnumerable<OfferProductType> offerProductTypes = null )
        {
            Type = type;
            Price = price;
            Category = category;
            Wares = wares ?? Array.Empty<Ware>();
            OfferProductTypes = offerProductTypes ?? Array.Empty<OfferProductType>();
        }

        public float CurrentPrice()
        {
            float currentPrice = Price;
            foreach(Offer o in _offerProductTypes.Select(op => op.Offer))
            {
                currentPrice *= (1-((float)o.Percentage / 100));
            }

            return currentPrice;
        }


        public void UpdateType(string type)
        {
            if(string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentNullException(nameof(type), "Cannot be null or empty");
            }
            Type = type;
        }

        public bool AddWare(Ware ware)
        {
            if (ware == null)
            {
                throw new ArgumentNullException(nameof(ware), "Cannot be null");
            }

            return _wares.Add(ware);
        }

        public bool RemoveWare(Ware ware)
        {
            if(ware == null)
            {
                throw new ArgumentNullException(nameof(ware), "Cannot be null");
            }

            return _wares.Remove(ware);
        }

        public void UpdateWare(Ware ware) 
        {
            Ware toUpdate = _wares.FirstOrDefault(w => w.WareId == ware.WareId);
            
            if(toUpdate == null)
            {
                throw new ArgumentException("Ware to update was not found", nameof(ware));
            }

            if(ware.SerialNumber != null)
            {
                toUpdate.UpdateSerialNumber(ware.SerialNumber);
            }
            
            if(ware.Location != null)
            {
                toUpdate.UpdateLocation(ware.Location);
            }
        }
    }
}
