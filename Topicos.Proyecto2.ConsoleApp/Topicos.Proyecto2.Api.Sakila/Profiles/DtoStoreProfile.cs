using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Topicos.Proyecto2.Api.Sakila.Profiles
{
    public class DtoStoreProfile : Profile
    {
        public DtoStoreProfile()
        {
            CreateMap<Proyecto2.Sakila.Model.Model.Store, DTOModels.DtoStore>();
        }
    }
}
