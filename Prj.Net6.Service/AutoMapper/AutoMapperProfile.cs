using AutoMapper;
using Prj.Net6.Core.Entities;
using Prj.Net6.Service.DTO;
using Prj.Net6.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Net6.Service.AutoMapper
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<Event, EventViewModel>().ReverseMap();
            CreateMap<ProjectDTO, Project>().ReverseMap();
        }

        //
    }
}
