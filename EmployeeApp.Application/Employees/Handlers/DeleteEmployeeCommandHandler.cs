using EmployeeApp.Application.Common.Interfaces;
using EmployeeApp.Application.Common.Results;
using EmployeeApp.Application.Employees.Commands;
using MediatR;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Result<Unit>>
{
    private readonly IApplicationDbContext _context;

    public DeleteEmployeeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<Unit>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var employee = await _context.Employees.FindAsync(new object[] { request.Id }, cancellationToken);

            if (employee == null)
            {
                return Result<Unit>.Failure("Employee not found.");
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync(cancellationToken);

            return Result<Unit>.Success(Unit.Value);
        }
        catch (Exception ex)
        {
            return Result<Unit>.Failure($"Error deleting employee: {ex.Message}");
        }
    }
}
