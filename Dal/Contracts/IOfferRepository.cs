using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Contracts
{
    public interface IOfferRepository
    {
        public Task<IEnumerable<Offer>> AllAsync();
        public Task<Offer> GetByIdAsync(int id);
        public Task<Offer> GetByIdAsyncWithRelationships(int id);
        public void Create(Offer offer);
        public void Update(Offer offer);
        public void Remove(Offer offer);
    }
}
