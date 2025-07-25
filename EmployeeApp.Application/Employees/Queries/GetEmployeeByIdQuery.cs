using MediatR;
using EmployeeApp.Application.Common.Results;
using EmployeeApp.Application.Employees.DTOs;
using System;

namespace EmployeeApp.Application.Employees.Queries
{
    public class GetEmployeeByIdQuery : IRequest<Result<EmployeeDto>>
    {
        public Guid Id { get; set; }

        public GetEmployeeByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}