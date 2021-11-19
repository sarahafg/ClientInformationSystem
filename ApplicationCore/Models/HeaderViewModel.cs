using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class HeaderViewModel
    {
        public List<ClientResponseModel> clientDropDown { get; set; }
        public List<EmployeeResponseModel> employeeDropDown { get; set; }
    }
}
