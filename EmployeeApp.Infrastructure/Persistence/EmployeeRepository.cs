using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeApp.Domain.Entities;
using EmployeeApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.Infrastructure.Persistence
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees
                .Where(e => e.IsActive)
                .ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(Guid id)
        {
            return await _context.Employees
                .FirstOrDefaultAsync(e => e.Id == id && e.IsActive);
        }

        public async Task AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee is not null)
            {
                employee.IsActive = false;
                await _context.SaveChangesAsync();
            }
        }
    }
}
