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
            
            CreateMap<Publication, PublicationForListDto>()
                .ForMember(dest => dest.PhotoUrls, opt => {
                    opt.MapFrom(src => src.Photos.Select(p => p.Url));
                })   
                .ForMember(dest => dest.Username, opt => {
                    opt.MapFrom(src => src.User.Username);
                });

            CreateMap<PublicationPhotoForCreationDto, PublicationPhoto>();
            CreateMap<PublicationForCreationDto, Publication>();
        }
    }
}