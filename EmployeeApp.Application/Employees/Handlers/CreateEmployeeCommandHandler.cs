using EmployeeApp.Application.Employees.Commands;
using EmployeeApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeApp.Application.Common.Interfaces;
using MediatR;
using EmployeeApp.Application.Common.Results;

namespace EmployeeApp.Application.Employees.Handlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Result<Guid>>
    {
        private readonly IApplicationDbContext _context;

        public CreateEmployeeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<Guid>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var employee = new Employee
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    JobTitle = request.JobTitle,
                    HireDate = request.HireDate,
                    Salary = request.Salary,
                    IsActive = request.IsActive
                };

                _context.Employees.Add(employee);
                await _context.SaveChangesAsync(cancellationToken);

                return Result<Guid>.Success(employee.Id);
            }
            catch (Exception ex)
            {
                return Result<Guid>.Failure($"Error creating employee: {ex.Message}");
            }
        }
    }
}
