using System;
using System.Collections.Generic;

namespace mmbm.Controllers.Resources
{
    public class BranchResource
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string UserId { get; set; }

        public DateTime? LastUpdate { get; set; }

        public ICollection<EmployeeResource> Employees { get; set; }
        public ICollection<ShopResource> Shops { get; set; }
        public ICollection<SimcardResource> Simcards { get; set; }
    }
}