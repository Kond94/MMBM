using System;

namespace mmbm.Core.Models
{
    public class ConsolidatedReport
    {
        public int Id { get; set; }
        public DateTime? LastUpdate { get; set; }

        public DateTime Date { get; set; }
        public MobileMoneyReport MobileMoneyReport { get; set; }
        public Employee Employee { get; set; }

    }
}