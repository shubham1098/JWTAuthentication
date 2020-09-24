using AutoMapper;
using JWTAuth.models;
using JWTAuth.Dtos;
using System;

namespace JWTAuth.Profiles
{
    public class JWTAuthProfile : Profile
    {
        public JWTAuthProfile()
        {
            CreateMap<User, UserReadDto>();

            CreateMap<UserCore, User>()
            .ForMember(d => d.Name, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
            .ForMember(d => d.DateCreated, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(d => d.UserRole, opt => opt.MapFrom(src => "user"));
        }
    }
}