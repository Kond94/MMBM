using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace mmbm.Core.Models
{
    [Table("Simcards")]
    public class Simcard
    {
        public int Id { get; set; }

        public string PhoneNumber { get; set; }
        public DateTime? LastUpdate { get; set; }


        public int BranchId { get; set; }

        public Branch Branch { get; set; }

        public Employee Employee { get; set; }
    }
}