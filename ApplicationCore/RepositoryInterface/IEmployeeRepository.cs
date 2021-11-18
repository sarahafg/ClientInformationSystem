using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IEmployeeRepository : IAsyncRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetEmployee();
        Task<Employee> GetEmployeeByName(string name);
        Task<Employee> GetEmployeeById(int id);
    }
}
