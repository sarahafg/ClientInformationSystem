using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IInteractionRepository : IAsyncRepository<Interaction>
    {
        Task<IEnumerable<Interaction>> GetInteraction();
        Task<Interaction> GetInteractionById(int id);
        Task<IEnumerable<Interaction>> GetInteractionByClientId(int ClientId);
        Task<IEnumerable<Interaction>> GetInteractionByEmpId(int EmpId);
        Task<Interaction> GetRemarksByClientId(int ClientId);
    }
}
