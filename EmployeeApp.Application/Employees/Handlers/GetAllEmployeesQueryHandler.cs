using MediatR;
using Microsoft.EntityFrameworkCore;
using EmployeeApp.Application.Common.Interfaces;
using EmployeeApp.Application.Employees.DTOs;
using EmployeeApp.Domain.Entities;

namespace EmployeeApp.Application.Employees.Queries;

public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, List<EmployeeDto>>
{
    private readonly IApplicationDbContext _context;

    public GetAllEmployeesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<EmployeeDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await _context.Employees
                .Select(e => new EmployeeDto
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email,
                    PhoneNumber = e.PhoneNumber,
                    JobTitle = e.JobTitle,
                    HireDate = e.HireDate,
                    Salary = e.Salary,
                    IsActive = e.IsActive
                })
                .ToListAsync(cancellationToken);
        }
        catch (Exception ex)
        {

            throw new Exception("An error occurred while retrieving employees.", ex);
        }
    }


}
