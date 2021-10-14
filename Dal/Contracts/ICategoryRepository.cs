using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Contracts
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> AllAsync();
        public Task<Category> GetByIdAsync(int id);
        public void Create(Category category);
        public void Update(Category category);
        public void Remove(Category category);
    }
}
