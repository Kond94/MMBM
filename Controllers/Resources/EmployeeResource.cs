using System;
using System.Collections.Generic;

namespace mmbm.Controllers.Resources
{
    public class EmployeeResource
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}