using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class InteractionPageViewModel
    {
        public HeaderViewModel header { get; set; }
        public List<InteractionResponseModel> interaction { get; set; }
    }
}
