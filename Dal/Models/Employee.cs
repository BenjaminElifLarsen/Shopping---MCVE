using Dal.Contracts;
using Dal.Models.JoiningTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Models
{
    public class Employee : IAggregateRoot
    {
        private HashSet<EmployeePermission> _employeePermissions;

        public int EmployeeId { get; private set; }
        public string Username { get; private set; }
        public string HashedPassword { get; private set; }
        public IEnumerable<EmployeePermission> EmployeePermissions { get => _employeePermissions; private set => _employeePermissions = value.ToHashSet(); }

        private Employee()
        {

        }

        public Employee(string username, string hashedPassword, IEnumerable<EmployeePermission> employeePermissions = null)
        {
            Username = username;
            HashedPassword = hashedPassword;
            EmployeePermissions = employeePermissions ?? Array.Empty<EmployeePermission>();
        }

        public bool AddEmployeePermission(EmployeePermission employeePermission)
        {
            if(employeePermission == null)
            {
                throw new ArgumentNullException(nameof(employeePermission), "Cannot be null.");
            }

            return _employeePermissions.Add(employeePermission);
        }

        public bool RemoveEmployeePermission(EmployeePermission employeePermission)
        {
            if (employeePermission == null)
            {
                throw new ArgumentNullException(nameof(employeePermission), "Cannot be null.");
            }

            return _employeePermissions.Remove(employeePermission);
        }
    }
}
