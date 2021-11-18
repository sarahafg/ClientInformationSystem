using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IDataService
    {
        Task<List<ClientResponseModel>> GetAllClient();
        Task<ClientResponseModel> GetClientByEmail(string email);
        Task<ClientResponseModel> GetClientById(int id);
        Task<List<EmployeeResponseModel>> GetAllEmployee();
        Task<EmployeeResponseModel> GetEmployeeByName(string name);
        Task<EmployeeResponseModel> GetEmployeeById(int id);
        Task<List<InteractionResponseModel>> GetAllInteraction();
        Task<InteractionResponseModel> GetInteractionById(int id);
        Task<List<InteractionResponseModel>> GetInteractionByClientId(int ClientId);
        Task<List<InteractionResponseModel>> GetInteractionByEmpId(int EmpId);
        Task<InteractionResponseModel> GetRemarksByClientId(int ClientId);
    }
}
