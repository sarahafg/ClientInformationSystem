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
    public class ClientRepository : EfRepository<Client>, IClientRepository
    {
        public ClientRepository(ClientInformationSystemDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<Client>> GetClient()
        {
            var client = await GetAll();

            return client;
        }

        public async Task<Client> GetClientByEmail(string email)
        {
            return await clientInformationSystemDbContext.Clients.FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task<Client> GetClientById(int id)
        {
            return await clientInformationSystemDbContext.Clients.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
