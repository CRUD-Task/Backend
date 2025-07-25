using MediatR;
using System.Collections.Generic;
using EmployeeApp.Application.Employees.DTOs;

namespace EmployeeApp.Application.Employees.Queries;

public class GetAllEmployeesQuery : IRequest<List<EmployeeDto>> { }