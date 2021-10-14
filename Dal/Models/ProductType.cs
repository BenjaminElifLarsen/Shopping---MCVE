using Dal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dal.Models
{
    public class ProductType : IAggregateRoot
    {
        private HashSet<Ware> _wares;

        public int ProductTypeId { get; private set; }
        public string Type { get; private set; }
        public int Prise { get; private set; }
        public IEnumerable<Ware> Wares { get => _wares; private set => _wares = value.ToHashSet(); }

        private ProductType()
        {

        }

        public ProductType(string type, int prise, IEnumerable<Ware> wares = null)
        {
            Type = type;
            Prise = prise;
            Wares = wares ?? Array.Empty<Ware>();
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

            toUpdate.UpdateSerialNumber(ware.SerialNumber);
            toUpdate.UpdateLocation(ware.Location);
        }
    }
}
