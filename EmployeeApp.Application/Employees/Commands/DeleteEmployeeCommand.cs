using EmployeeApp.Application.Common.Results;
using MediatR;

public class DeleteEmployeeCommand : IRequest<Result<Unit>>
{
    public Guid Id { get; set; }

    public DeleteEmployeeCommand(Guid id)
    {
        Id = id;
    }
}
