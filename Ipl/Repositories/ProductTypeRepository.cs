using Dal.Contracts;
using Dal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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

        public async Task<ProductType> GetByIdAsyncWithRelationships(int id)
        {
            return await _repository.FetchSingleOrDefaultByQueryObjectAsync(p => p.ProductTypeId == id, p => p.OfferProductTypes.Include(), p => p.Wares);
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
