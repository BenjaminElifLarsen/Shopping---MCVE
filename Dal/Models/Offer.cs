using Dal.Contracts;
using Dal.Models.JoiningTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Models
{
    public class Offer : IAggregateRoot
    {
        private HashSet<OfferProductType> _offerProductTypes;

        public int OfferId { get; private set; }
        public string Title { get; private set; }
        public byte Percentage { get; private set; }
        public string Reason { get; private set; }
        public bool Active { get; private set; }
        public IEnumerable<OfferProductType> OfferProductTypes { get => _offerProductTypes; private set => _offerProductTypes = value.ToHashSet(); }

        private Offer()
        {

        }

        public Offer(string title, byte percentage, string reason, bool active, IEnumerable<OfferProductType> offerProductTypes = null)
        {
            Title = title;
            Percentage = percentage;
            Reason = reason;
            Active = active;
            OfferProductTypes = offerProductTypes ?? Array.Empty<OfferProductType>();
        }

        public void UpdateActive(bool active)
        {
            Active = active;
        }

        public void UpdateReason(string reason)
        {
            if(string.IsNullOrWhiteSpace(reason))
            {
                throw new ArgumentNullException(nameof(reason), "Cannot be null or empty.");
            }

            if (Active)
            {
                throw new ArgumentException("Cannot change value if the offer is active");
            }

            Reason = reason;
        }

        public void UpdateTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException(nameof(title), "Cannot be null or empty.");
            }

            if (Active)
            {
                throw new ArgumentException("Cannot change value if the offer is active.");
            }

            Title = title;
        }

        public void UpdatePercentage(byte percentage)
        {
            if(percentage >= 100)
            {
                throw new ArgumentOutOfRangeException(nameof(percentage), "Cannot be 100 or more.");
            }


            if (percentage == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(percentage), "Cannot be 0.");
            }

            if (Active)
            {
                throw new ArgumentException("Cannot change value if the offer is active.");
            }

            Percentage = percentage;
        }

        public bool AddProductToOffer(ProductType productType)
        {
            if(productType == null)
            {
                throw new ArgumentNullException(nameof(productType), "Cannot be null.");
            }

            return _offerProductTypes.Add(new(this, productType));
        }

        public bool RemoveProductToOffer(ProductType productType)
        {
            if (productType == null)
            {
                throw new ArgumentNullException(nameof(productType), "Cannot be null.");
            }

            return _offerProductTypes.Remove(_offerProductTypes.SingleOrDefault(op => op.OfferId == OfferId && op.ProductTypeId == productType.ProductTypeId));
        }
    }
}
