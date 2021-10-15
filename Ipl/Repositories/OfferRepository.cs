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
    class OfferRepository : IOfferRepository
    {
        private readonly ShopDbContext _shopDbContext;
        public OfferRepository(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }

        public async Task<IEnumerable<Offer>> AllAsync()
        {
            return await _shopDbContext.Offers.ToArrayAsync();
        }

        public void Create(Offer offer)
        {
            _shopDbContext.Add(offer);
        }

        public async Task<Offer> GetByIdAsync(int id)
        {
            return await _shopDbContext.Offers.SingleOrDefaultAsync(o => o.OfferId == id);
        }

        public async Task<Offer> GetByIdAsyncWithRelationships(int id)
        {
            return await _shopDbContext.Offers
                .Include(o => o.OfferProductTypes)
                    .ThenInclude(op => op.ProductType)
                .SingleOrDefaultAsync(o => o.OfferId == id);
        }

        public void Remove(Offer offer)
        {
            _shopDbContext.Remove(offer);
        }

        public void Update(Offer offer)
        {
            _shopDbContext.Update(offer);
        }
    }
}
