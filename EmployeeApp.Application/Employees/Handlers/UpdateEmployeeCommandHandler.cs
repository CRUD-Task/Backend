using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeApp.Application.Employees.Commands;
using System;
using EmployeeApp.Application.Common.Interfaces;
using EmployeeApp.Application.Common.Results;

namespace EmployeeApp.Application.Employees.Handlers;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Result<Unit>>
{
    private readonly IApplicationDbContext _context;

    public UpdateEmployeeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<Unit>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var employee = await _context.Employees.FindAsync(request.Id);

            if (employee == null)
                return Result<Unit>.Failure("Employee not found.");

            employee.FirstName = request.FirstName;
            employee.LastName = request.LastName;
            employee.Email = request.Email;
            employee.PhoneNumber = request.PhoneNumber;
            employee.JobTitle = request.JobTitle;
            employee.Salary = request.Salary;
            employee.IsActive = request.IsActive;

            await _context.SaveChangesAsync(cancellationToken);

            return Result<Unit>.Success(Unit.Value);
        }
        catch (Exception ex)
        {
            return Result<Unit>.Failure($"Update failed: {ex.Message}");
        }
    }
}
