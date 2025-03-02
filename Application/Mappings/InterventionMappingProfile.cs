using AutoMapper;
using Domain.Entities;
using Application.DTOs;

namespace Application.Mappings
{
	public class InterventionMappingProfile : Profile
	{
		public InterventionMappingProfile()
		{
			CreateMap<Intervention, InterventionDto>()
				.ForMember(dest => dest.ContractNumber, opt => opt.MapFrom(src => src.Contract.ContractNumber))
				.ForMember(dest => dest.SystemTypeName, opt => opt.MapFrom(src => src.SystemType.Name))
				.ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => src.Client.Name))
				.ForMember(dest => dest.TechnicianName, opt => opt.MapFrom(src => src.Technician.Name))
				.ForMember(dest => dest.StatusName, opt => opt.MapFrom(src => src.Status.StatusName));
		}
	}
}
