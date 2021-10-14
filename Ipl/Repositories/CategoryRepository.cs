using Dal.Contracts;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ipl.Repositories
{
    class CategoryRepository : ICategoryRepository
    {
        private Repository<Category> _repository;

        public CategoryRepository(Repository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Category>> AllAsync()
        {
            return await _repository.AllAsync();
        }

        public void Create(Category category)
        {
            _repository.Create(category);
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _repository.FetchSingleOrDefaultByQueryObjectAsync(c => c.CategoryId == id);
        }

        public void Remove(Category category)
        {
            _repository.Delete(category);
        }

        public void Update(Category category)
        {
            _repository.Update(category);
        }
    }
}
