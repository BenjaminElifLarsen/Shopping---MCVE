using Dal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Models
{
    public class Category : IAggregateRoot
    {
        private HashSet<ProductType> _productType;

        public int CategoryId { get; private set; }
        public string Name { get; private set; }
        public IEnumerable<ProductType> ProductTypes { get => _productType; private set => _productType = value.ToHashSet(); }

        private Category()
        {

        }

        public Category(string name, IEnumerable<ProductType> productTypes = null)
        {
            Name = name;
            ProductTypes = productTypes ?? Array.Empty<ProductType>();
        }

        public bool AddWare(ProductType productType)
        {
            if(productType == null)
            {
                throw new ArgumentNullException(nameof(productType), "Cannot be null.");
            }

            return _productType.Add(productType);
        }

        public bool RemoveWare(ProductType productType)
        {
            if (productType == null)
            {
                throw new ArgumentNullException(nameof(productType), "Cannot be null.");
            }

            return _productType.Remove(productType);
        }
    }
}
