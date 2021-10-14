using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Models.JoiningTables
{
    public class OfferProductType
    {
        public int OfferId { get; private set; }
        public Offer Offer { get; private set; }
        public int ProductTypeId { get; private set; }
        public ProductType ProductType { get; private set; }

        public OfferProductType(Offer offer, ProductType productType)
        {
            Offer = offer;
            ProductType = productType;
        }
    }
}
