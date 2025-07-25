using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }             
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string JobTitle { get; set; } = null!;
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
