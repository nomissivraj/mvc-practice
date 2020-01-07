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
            Mapper.CreateMap<CustomerModel, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, CustomerModel>();
            Mapper.CreateMap<MovieModel, MovieDTO>();
            Mapper.CreateMap<MovieDTO, MovieModel>();
        }
    }
}