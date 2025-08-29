using AutoMapper;
using RTC_OEE_Management_API.Models.DTO;
using RTC_OEE_Management_API.Models.Entities;

namespace RTC_OOE.API.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Factory, FactoryDTO>().ReverseMap();
            CreateMap<Zone, ZoneDTO>().ReverseMap();
            CreateMap<Machine, MachineDTO>().ReverseMap();
            CreateMap<Model,ModelDTO>().ReverseMap();
            CreateMap<PlannedDowntime,PlannedDowntimeDTO>().ReverseMap();
            CreateMap<UnplannedDowntimeReason,UnplannedDowntimeReasonDTO>().ReverseMap();
        }
    }

}
