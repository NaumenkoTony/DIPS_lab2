using AutoMapper;
using ReservationService.Models.DomainModels;
using ReservationService.Models.Dto;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Hotel, HotelResponse>();
    }
}
