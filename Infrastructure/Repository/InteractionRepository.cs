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
    public class InteractionRepository : EfRepository<Interaction>, IInteractionRepository
    {
        public InteractionRepository(ClientInformationSystemDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<Interaction>> GetInteraction()
        {
            return await clientInformationSystemDbContext.Interactions.Include(i => i.Clients).Include(i => i.Employees)
                .ToListAsync();
        }

        public async Task<IEnumerable<Interaction>> GetInteractionByClientId(int ClientId)
        {
            return await clientInformationSystemDbContext.Interactions.Include(i => i.Clients).Include(i => i.Employees)
                .Where(i => i.ClientId == ClientId).ToListAsync();
        }

        public async Task<IEnumerable<Interaction>> GetInteractionByEmpId(int EmpId)
        {
            return await clientInformationSystemDbContext.Interactions.Include(i => i.Clients).Include(i => i.Employees)
                .Where(i => i.EmployeeId == EmpId).ToListAsync();
        }

        public async Task<Interaction> GetInteractionById(int id)
        {
            return await clientInformationSystemDbContext.Interactions.Include(i => i.Clients).Include(i => i.Employees)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Interaction> GetRemarksByClientId(int ClientId)
        {
            return await clientInformationSystemDbContext.Interactions.Include(i => i.Clients).Include(i => i.Employees)
                .FirstOrDefaultAsync(i => i.ClientId == ClientId);
        }
    }
}
