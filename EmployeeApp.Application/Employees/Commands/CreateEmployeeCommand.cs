using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeApp.Application.Common.Results;
using MediatR;

namespace EmployeeApp.Application.Employees.Commands
{
    public class CreateEmployeeCommand : IRequest<Result<Guid>>
    {
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
