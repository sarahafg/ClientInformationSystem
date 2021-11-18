using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Interaction
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int EmployeeId { get; set; }

        [MaxLength(1)]
        public string? IntType { get; set; }

        [MaxLength(100)]
        public DateTime? IntDate { get; set; }

        [MaxLength(500)]
        public string? Remarks { get; set; }

        public Client Clients { get; set; }
        public Employee Employees { get; set; }
    }
}