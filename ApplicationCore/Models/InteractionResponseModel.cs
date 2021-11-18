using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class InteractionResponseModel
    {
        public int Id { get; set; }

        public string ClientName { get; set; }

        public string EmpName { get; set; }

        public string? IntType { get; set; }

        public DateTime? IntDate { get; set; }

        public string? Remarks { get; set; }
    }
}
