using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Contracts
{
    public interface IEmployeeRepository
    {
        public Task<IEnumerable<Employee>> AllAsync();
        public Task<Employee> GetByIdAsync(int id);
        public void Create(Employee employee);
        public void Update(Employee employee);
        public void Remove(Employee employee);
    }
}
