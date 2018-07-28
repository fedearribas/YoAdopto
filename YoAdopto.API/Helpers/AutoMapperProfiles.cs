using System;
using System.Linq;
using AutoMapper;
using YoAdopto.API.Dtos;
using YoAdopto.API.Models;

namespace YoAdopto.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserToReturnDto>();
            CreateMap<UserForRegisterDto, User>();
        }
    }
}