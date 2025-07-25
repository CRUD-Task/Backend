using EmployeeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Employee> Employees { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
