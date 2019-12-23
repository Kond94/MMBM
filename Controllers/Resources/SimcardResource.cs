using System;

namespace mmbm.Controllers.Resources
{
    public class SimcardResource
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? LastUpdate { get; set; }
        public EmployeeResource Employee { get; set; }
    }
}