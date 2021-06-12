using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsedCars.Core.Entities;
using UsedCars.Web.Models;

namespace UsedCars.Web.MappingProfiles
{
    public class MainMappingProfile : Profile
    {
        public MainMappingProfile()
        {
            CreateMap<AvKeboardProgram, KeyboardProgramsViewModel>();
        }
        
    }
}
