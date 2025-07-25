using EmployeeApp.Application.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Application.Employees.Commands
{
    public class UpdateEmployeeCommand : IRequest<Result<Unit>>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
    }
}
