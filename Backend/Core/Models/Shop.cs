using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace mmbm.Core.Models
{
    [Table("Shops")]
    public class Shop
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime? LastUpdate { get; set; }


        public int BranchId { get; set; }

        public Branch Branch { get; set; }

        public int? EmployeeId { get; set; }

        public Employee Employee { get; set; }

    }
}