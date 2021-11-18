using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class DataService : IDataService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IInteractionRepository _interactionRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public DataService(IClientRepository clientRepository, IEmployeeRepository employeeRepository, IInteractionRepository interactionRepository)
        {
            _clientRepository = clientRepository;
            _employeeRepository = employeeRepository;
            _interactionRepository = interactionRepository;

        }

        public async Task<List<ClientResponseModel>> GetAllClient()
        {
            //return (ClientResponseModel)await _clientRepository.GetClient();

            var clients = await _clientRepository.GetAll();
            if (clients == null)
            {
                return null;
            }
            return (from clientDetails in clients
                    select new ClientResponseModel
            {
                Id = clientDetails.Id,
                Name = clientDetails.Name,
                Email = clientDetails.Email,
                Phones = clientDetails.Phones,
                Address = clientDetails.Address,
                AddedOn = clientDetails.AddedOn
            }).ToList();
        }

        public async Task<List<InteractionResponseModel>> GetAllInteraction()
        {
            var inter = await _interactionRepository.GetInteraction();
            if (inter == null)
            {
                return null;
            }
            return (from interDetails in inter
                    select new InteractionResponseModel
                    {
                        Id = interDetails.Id,
                        ClientName = interDetails.Clients.Name,
                        EmpName = interDetails.Employees.Name,
                        IntDate = interDetails.IntDate,
                        IntType = interDetails.IntType,
                        Remarks = interDetails.Remarks
                    }).ToList();
        }

        public async Task<List<EmployeeResponseModel>> GetAllEmployee()
        {
            var employee = await _employeeRepository.GetAll();
            if (employee == null)
            {
                return null;
            }
            return (from employeeDetails in employee
                    select new EmployeeResponseModel
                    {
                        Id = employeeDetails.Id,
                        Name = employeeDetails.Name,
                        Password = employeeDetails.Password,
                        Designation = employeeDetails.Designation
                    }).ToList();
        }

        public async Task<ClientResponseModel> GetClientByEmail(string email)
        {
            var client = await _clientRepository.GetClientByEmail(email);
            if (client == null)
            {
                return null;
            }
            var clientDetails = new ClientResponseModel
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                Phones = client.Phones,
                Address = client.Address,
                AddedOn = client.AddedOn
             };
            return clientDetails;
        }

        public async Task<ClientResponseModel> GetClientById(int id)
        {
            var client = await _clientRepository.GetClientById(id);
            if (client == null)
            {
                return null;
            }
            var clientDetails = new ClientResponseModel
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                Phones = client.Phones,
                Address = client.Address,
                AddedOn = client.AddedOn
            };
            return clientDetails;
        }

        public async Task<EmployeeResponseModel> GetEmployeeByName(string name)
        {
            var employee = await _employeeRepository.GetEmployeeByName(name);
            if (employee == null)
            {
                return null;
            }
            var employeeDetails = new EmployeeResponseModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Password = employee.Password,
                Designation = employee.Designation
            };
            return employeeDetails;
        }

        public async Task<EmployeeResponseModel> GetEmployeeById(int id)
        {
            var employee = await _employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return null;
            }
            var employeeDetails = new EmployeeResponseModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Password = employee.Password,
                Designation = employee.Designation
            };
            return employeeDetails;
        }

        public async Task<InteractionResponseModel> GetInteractionById(int id)
        {
            var inter = await _interactionRepository.GetInteractionById(id);
            if (inter == null)
            {
                return null;
            }
            var interDetails = new InteractionResponseModel
            {
                Id = inter.Id,
                ClientName = inter.Clients.Name,
                EmpName = inter.Employees.Name,
                IntDate = inter.IntDate,
                IntType = inter.IntType,
                Remarks = inter.Remarks

            };
            return interDetails;
        }

        public async Task<List<InteractionResponseModel>> GetInteractionByClientId(int ClientId)
        {
            var inter = await _interactionRepository.GetInteractionByClientId(ClientId);
            if (inter == null)
            {
                return null;
            }
            return (from interDetails in inter
                    select new InteractionResponseModel
                    { 
                Id = interDetails.Id,
                ClientName = interDetails.Clients.Name,
                EmpName = interDetails.Employees.Name,
                IntDate = interDetails.IntDate,
                IntType = interDetails.IntType,
                Remarks = interDetails.Remarks

            }).ToList();
        }

        public async Task<List<InteractionResponseModel>> GetInteractionByEmpId(int EmpId)
        {
            var inter = await _interactionRepository.GetInteractionByEmpId(EmpId);
            if (inter == null)
            {
                return null;
            }
            return (from interDetails in inter
                    select new InteractionResponseModel
                    {
                        Id = interDetails.Id,
                ClientName = interDetails.Clients.Name,
                EmpName = interDetails.Employees.Name,
                IntDate = interDetails.IntDate,
                IntType = interDetails.IntType,
                Remarks = interDetails.Remarks

            }).ToList();
        }

        public async Task<InteractionResponseModel> GetRemarksByClientId(int ClientId)
        {
            var inter = await _interactionRepository.GetRemarksByClientId(ClientId);
            if (inter == null)
            {
                return null;
            }
            var interDetails = new InteractionResponseModel
            {
                Id = inter.Id,
                ClientName = inter.Clients.Name,
                EmpName = inter.Employees.Name,
                IntDate = inter.IntDate,
                IntType = inter.IntType,
                Remarks = inter.Remarks

            };
            return interDetails;
        }
    }
}
