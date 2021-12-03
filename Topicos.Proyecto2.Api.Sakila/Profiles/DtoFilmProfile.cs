using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Topicos.Proyecto2.Api.Sakila.Profiles
{
    public class DtoFilmProfile : Profile
    {
        public DtoFilmProfile()
        {
            CreateMap<Proyecto2.Sakila.Model.MyModels.Film, DtoModel.DtoFilm>();
        }
    }
}
