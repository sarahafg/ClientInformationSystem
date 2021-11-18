using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Client
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string? Name { get; set; }

        [MaxLength(50)]
        public string? Email { get; set; }

        [MaxLength(30)]
        public string? Phones { get; set; }

        [MaxLength(100)]
        public string? Address { get; set; }

        public DateTime? AddedOn { get; set; }

        public ICollection<Interaction> Interactions { get; set; }
    }
}