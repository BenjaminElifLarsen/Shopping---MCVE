using Dal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Models
{
    public class Permission : IAggregateRoot
    {
        private HashSet<EmployeePermission> _employeePermissions;

        public int PermissionId { get; private set; }
        public string Type { get; private set; }
        public IEnumerable<EmployeePermission> EmployeePermissions { get => _employeePermissions; private set => _employeePermissions = value.ToHashSet(); }

        private Permission()
        {

        }

        public bool AddEmployeePermission(EmployeePermission employeePermission)
        {
            if (employeePermission == null)
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
