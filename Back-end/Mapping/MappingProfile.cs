using AutoMapper;
using HotelManagementApplication.BLL.DTOs;
using HotelManagementApplication.Models;

namespace HotelManagementApplication.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<HotelDTO, Hotel>().ReverseMap();
            CreateMap<RoomDTO, Room>().ReverseMap();
            CreateMap<ReservationDTO, Reservation>().ReverseMap();
            CreateMap<CustomerDTO, Customer>().ReverseMap();
            CreateMap<EmployeeDTO, Employee>().ReverseMap();
        }
    }
}
