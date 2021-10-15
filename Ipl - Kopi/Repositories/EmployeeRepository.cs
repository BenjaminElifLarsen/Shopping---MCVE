using Dal.Contracts;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ipl.Repositories
{
    class EmployeeRepository : IEmployeeRepository
    {
        private Repository<Employee> _repository;

        public EmployeeRepository(Repository<Employee> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Employee>> AllAsync()
        {
            return await _repository.AllAsync();
        }

        public void Create(Employee employee)
        {
            _repository.Create(employee);
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _repository.FetchSingleOrDefaultByQueryObjectAsync(e => e.EmployeeId == id);
        }

        public Task<Employee> GetByIdAsyncWithRelationships(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Employee employee)
        {
            _repository.Delete(employee);
        }

        public void Update(Employee employee)
        {
            _repository.Update(employee);
        }
    }
}
