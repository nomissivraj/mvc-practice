using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.Models;
using Vidly.DTOs;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            //Domain to DTO
            Mapper.CreateMap<CustomerModel, CustomerDTO>();
            Mapper.CreateMap<MovieModel, MovieDTO>();

            //DTO to Domain
            Mapper.CreateMap<CustomerDTO, CustomerModel>()
                .ForMember(c=>c.ID, opt => opt.Ignore());
            Mapper.CreateMap<MovieDTO, MovieModel>()

                .ForMember(c => c.ID, opt => opt.Ignore());
        }
    }
}