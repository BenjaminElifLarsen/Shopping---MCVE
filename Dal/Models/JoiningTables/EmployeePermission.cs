using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Models.JoiningTables
{
    public class EmployeePermission
    {
        public int EmployeeId { get; private set; }
        public Employee Employee { get; private set; }

        public int PermissionId { get; private set; }
        public Permission Permission { get; private set; }

        private EmployeePermission()
        {

        }

        public EmployeePermission(Employee employee, Permission permission)
        {
            Employee = employee ?? throw new ArgumentNullException(nameof(employee), "Cannot be null");
            Permission = permission ?? throw new ArgumentNullException(nameof(permission), "Cannot be null");
        }

    }
}
