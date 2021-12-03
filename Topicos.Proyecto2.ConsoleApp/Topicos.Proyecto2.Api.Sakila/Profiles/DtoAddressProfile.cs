using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Topicos.Proyecto2.Api.Sakila.Profiles
{
    public class DtoAddressProfile : Profile
    {
        public DtoAddressProfile()
        {
            CreateMap<Proyecto2.Sakila.Model.Model.Address, DTOModels.DtoAddress>();
        }
    }
}
