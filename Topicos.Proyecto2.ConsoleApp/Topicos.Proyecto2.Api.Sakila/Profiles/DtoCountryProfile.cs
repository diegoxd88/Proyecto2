using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Topicos.Proyecto2.Api.Sakila.Profiles
{
    public class DtoCountryProfile : Profile
    {
        public DtoCountryProfile()
        {
            CreateMap<Proyecto2.Sakila.Model.Model.Customer, DTOModels.DtoCustomer>();
        }
    }
}
