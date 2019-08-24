using AutoMapper;
using PersonalDiary.Service.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalDiary.Service.AutoMapperConfig
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Entities.PersonalDiary, PersonalDiaryDto>().ReverseMap();
            CreateMap<Entities.Image, ImageDto>().ReverseMap();
        }

    }
}
