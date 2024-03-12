using AutoMapper;
using MediumSite.Application.UseCases.Commands;
using MediumSite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediumSite.Application.Abstractions.Mapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, CreateUserCommand>().ReverseMap();
        }

    }
}
