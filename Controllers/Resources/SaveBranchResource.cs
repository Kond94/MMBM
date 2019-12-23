using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace mmbm.Controllers.Resources
{
    public class SaveBranchResource
    {
        public string Name { get; set; }

        public string UserId { get; set; }
    }
}