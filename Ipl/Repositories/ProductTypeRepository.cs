using Dal.Contracts;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ipl.Repositories
{
    class ProductTypeRepository : IProductTypeRepository
    {
        private Repository<ProductType> _repository;

        public ProductTypeRepository(Repository<ProductType> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductType>> AllAsync()
        {
            return await _repository.AllAsync();
        }

        public void Create(ProductType productType)
        {
            _repository.Create(productType);
        }

        public async Task<ProductType> GetByIdAsync(int id)
        {
            return await _repository.FetchSingleOrDefaultByQueryObjectAsync(p => p.ProductTypeId == id);
        }

        public void Remove(ProductType productType)
        {
            _repository.Delete(productType);
        }

        public void Update(ProductType productType)
        {
            _repository.Update(productType);
        }
    }
}
