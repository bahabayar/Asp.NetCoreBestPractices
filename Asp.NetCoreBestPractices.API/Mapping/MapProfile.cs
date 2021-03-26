using Asp.NetCoreBestPractices.API.DTOs;
using Asp.NetCoreBestPractices.Core.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCoreBestPractices.API.Mapping
{
    public class MapProfile:Profile
    {
     
        public MapProfile()
        {
            CreateMap<Category,CategoryDto>();
            CreateMap<CategoryDto,Category>();
        }
    }
}
