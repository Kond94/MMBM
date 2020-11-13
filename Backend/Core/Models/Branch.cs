using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace mmbm.Core.Models
{
    [Table("Branches")]
    public class Branch
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string UserId { get; set; }
        public DateTime? LastUpdate { get; set; }


        public ICollection<Employee> Employees { get; set; }

        public ICollection<Simcard> Simcards { get; set; }

        public ICollection<Shop> Shops { get; set; }

    }
}