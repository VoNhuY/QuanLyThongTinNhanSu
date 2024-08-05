using AutoMapper;
using Entities.DAOs;
using Entities.DTOs.CRUD;
using System.Security.Claims;


namespace Services.Implementation.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Phongban, PhongBanDTO>();
            CreateMap<Phongban, PhongBanDTO>();
            CreateMap<PhongBanForCreationDTO, Phongban>();
            CreateMap<PhongBanForUpdateDTO, Phongban>();
        }
    }
}
