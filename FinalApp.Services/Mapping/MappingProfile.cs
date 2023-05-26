﻿using AutoMapper;
using FinalApp.ApiModels.DTOs.CommonDTOs.BaseDTOs;
using FinalApp.ApiModels.DTOs.EntitiesDTOs.UsersDTOs;
using FinalApp.Domain.Models.Abstractions.BaseUsers;
using FinalApp.Domain.Models.Entities.Persons.Users;

namespace FinalApp.Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BaseUser, BaseUserDTO>();
            CreateMap<Client, ClientDTO>();
            CreateMap<TechTeam, TechTeamDTO>();
            CreateMap<SupportOperator, SupportOperatorDTO>();
        }
    }
}