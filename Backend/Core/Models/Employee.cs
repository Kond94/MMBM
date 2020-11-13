using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace mmbm.Core.Models
{
    [Table("Employees")]
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public DateTime? LastUpdate { get; set; }

        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        public ICollection<Simcard> Simcards { get; set; }
        public ICollection<ConsolidatedReport> Reports { get; set; }
        public Shop Shop { get; set; }
    }
}