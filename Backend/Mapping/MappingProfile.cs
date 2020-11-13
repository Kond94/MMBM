using AutoMapper;
using System.Linq;
using mmbm.Controllers.Resources;
using mmbm.Core.Models;

namespace mmbm.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to API Resource
            CreateMap<Branch, BranchResource>();
            CreateMap<BranchResource, Branch>();
            CreateMap<SaveBranchResource, Branch>()
              .ForMember(v => v.Id, opt => opt.Ignore());

            CreateMap<Employee, EmployeeResource>();
            CreateMap<EmployeeResource, Employee>();
            CreateMap<SaveEmployeeResource, Employee>()
              .ForMember(v => v.Id, opt => opt.Ignore());

            CreateMap<Shop, ShopResource>();
            CreateMap<ShopResource, Shop>();
            CreateMap<SaveShopResource, Shop>()
              .ForMember(v => v.Id, opt => opt.Ignore());

            CreateMap<Simcard, SimcardResource>();
            CreateMap<SimcardResource, Simcard>();
            CreateMap<SaveSimcardResource, Simcard>()
              .ForMember(v => v.Id, opt => opt.Ignore());


        }
    }
}