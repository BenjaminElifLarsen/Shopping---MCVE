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

        public Task<IEnumerable<Category>> AllAsync()
        {
            throw new NotImplementedException();
        }

        public void Create(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Category category)
        {
            throw new NotImplementedException();
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
