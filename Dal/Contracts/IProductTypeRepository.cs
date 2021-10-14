using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Contracts
{
    public interface IProductTypeRepository
    {
        public Task<IEnumerable<ProductType>> AllAsync();
        public Task<ProductType> GetByIdAsync(int id);
        public void Create(ProductType productType);
        public void Update(ProductType productType);
        public void Remove(ProductType productType);
    }
}
