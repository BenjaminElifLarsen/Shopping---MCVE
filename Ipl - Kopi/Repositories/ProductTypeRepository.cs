using Dal.Contracts;
using Dal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Dal.Models.JoiningTables;
using Microsoft.EntityFrameworkCore;

namespace Ipl.Repositories
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private Repository<ProductType> _repository;

        public readonly DbSet<ProductType> _entities;

        public DbSet<ProductType> entites { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public ProductTypeRepository(Repository<ProductType> repository)
        {
            _repository = repository;
            _entities = repository._entities;
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
            return await _repository.FetchSingleOrDefaultByQueryObjectAsync(p => p.ProductTypeId == id, p => (p.Wares as Ware).Location, p => (p.OfferProductTypes as OfferProductType).Offer, p => (p.Category as Category));
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
