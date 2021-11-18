using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository : EfRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ClientInformationSystemDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<Employee>> GetEmployee()
        {
            var employee = await GetAll();
            return employee;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await clientInformationSystemDbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Employee> GetEmployeeByName(string name)
        {
            return await clientInformationSystemDbContext.Employees.FirstOrDefaultAsync(e => e.Name == name);
        }
    }
}
