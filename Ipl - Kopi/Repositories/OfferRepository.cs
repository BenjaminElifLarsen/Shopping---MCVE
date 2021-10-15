using Dal.Contracts;
using Dal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ipl.Repositories
{
    class OfferRepository : IOfferRepository
    {
        private Repository<Offer> _repository;

        public OfferRepository(Repository<Offer> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Offer>> AllAsync()
        {
            return await _repository.AllAsync();
        }

        public void Create(Offer offer)
        {
            _repository.Create(offer);
        }

        public async Task<Offer> GetByIdAsync(int id)
        {
            return await _repository.FetchSingleOrDefaultByQueryObjectAsync(o => o.OfferId == id);
        }

        public Task<Offer> GetByIdAsyncWithRelationships(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(Offer offer)
        {
            _repository.Delete(offer);
        }

        public void Update(Offer offer)
        {
            _repository.Update(offer);
        }
    }
}
