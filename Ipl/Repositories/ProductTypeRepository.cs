using Dal.Contracts;
using Dal.Models;
using Ipl.Databases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ipl.Repositories
{
    class ProductTypeRepository : IProductTypeRepository
    {
        private readonly ShopDbContext _shopDbContext;
        public ProductTypeRepository(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }

        public async Task<IEnumerable<ProductType>> AllAsync()
        {
            return await _shopDbContext.ProductTypes.ToArrayAsync();
        }

        public void Create(ProductType productType)
        {
            _shopDbContext.Add(productType);
        }

        public async Task<ProductType> GetByIdAsync(int id)
        {
            return await _shopDbContext.ProductTypes.SingleOrDefaultAsync(p => p.ProductTypeId == id);
        }

        public async Task<ProductType> GetByIdAsyncWithRelationships(int id)
        {
            return await _shopDbContext.ProductTypes
                .Include(p => p.OfferProductTypes)
                    .ThenInclude(op => op.Offer)
                .Include(p => p.Wares)
                .Include(p => p.Category)
                .SingleOrDefaultAsync(p => p.ProductTypeId == id);
        }

        public void Remove(ProductType productType)
        {
            _shopDbContext.Remove(productType);
        }

        public void Update(ProductType productType)
        {
            _shopDbContext.Update(productType);
        }
    }
}
