using AutoMapper;
using Musala.Gateways.Data.Database;
using Musala.Gateways.Domain.Models;

namespace Musala.Gateways.Domain.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile(string profile)
        {
        }
        
        public MappingProfile():this("Profile")
        {
            CreateMap<DeviceModel, DatDevice>().ForMember(dest => dest.NumUid, opt => opt.MapFrom(src => src.Uid))
                .ForMember(dest => dest.DesVendor, opt => opt.MapFrom(src => src.Vendor))
                .ForMember(dest => dest.FlgStatus, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.FkGateway, opt => opt.MapFrom(src => src.IdGateway));

            CreateMap<GatewayModel, DatGateway>()
                .ForMember(dest => dest.DesSerialNumber, opt => opt.MapFrom(src => src.SerialNumber))
                .ForMember(dest => dest.DesName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.DesIpv4, opt => opt.MapFrom(src => src.Ipv4));

        }
    }
}