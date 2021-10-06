using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper.Mappers;
using AutoMapper;
using MVC_Course_V2.Dtos;
using MVC_Course_V2.Models;

namespace MVC_Course_V2.App_Start
{
    public class MappingProfile:Profile
    {

        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>()
             .ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<CustomerDto, Customer>();
                
            CreateMap<Movie,MovieDto>()
                    .ForMember(m => m.Id, opt => opt.Ignore());
            CreateMap<MovieDto, Movie>();
                
        }
            
        

    }
}