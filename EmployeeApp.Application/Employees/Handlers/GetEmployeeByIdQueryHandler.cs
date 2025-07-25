using EmployeeApp.Application.Common.Results;
using EmployeeApp.Application.Employees.DTOs;
using EmployeeApp.Application.Employees.Queries;
using EmployeeApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeApp.Application.Employees.Handlers
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Result<EmployeeDto>>
    {
        private readonly IApplicationDbContext _context;


        public GetEmployeeByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<EmployeeDto>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var employee = await _context.Employees
                    .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

                if (employee == null)
                    return Result<EmployeeDto>.Failure("Employee not found.");

                var employeeDto = new EmployeeDto
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    PhoneNumber = employee.PhoneNumber,
                    JobTitle = employee.JobTitle,
                    HireDate = employee.HireDate,
                    Salary = employee.Salary,
                    IsActive = employee.IsActive
                };

                return Result<EmployeeDto>.Success(employeeDto);
            }
            catch (Exception ex)
            {
                return Result<EmployeeDto>.Failure($"An error occurred while retrieving the employee: {ex.Message}");
            }
        }

    }
}
