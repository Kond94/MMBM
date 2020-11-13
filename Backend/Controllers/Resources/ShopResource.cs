using System;

namespace mmbm.Controllers.Resources
{
    public class ShopResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? LastUpdate { get; set; }

        public EmployeeResource Employee { get; set; }
    }
}