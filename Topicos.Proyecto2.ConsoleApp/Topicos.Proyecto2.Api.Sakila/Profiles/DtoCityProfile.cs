using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Topicos.Proyecto2.Api.Sakila.Profiles
{
    public class DtoCityProfile : Profile
    {
        public DtoCityProfile()
        {
            CreateMap<Proyecto2.Sakila.Model.Model.City, DTOModels.DtoCity>();
        }
    }
}
