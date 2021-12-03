using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Topicos.Proyecto2.Api.Sakila.Profiles
{
    public class DtoActorProfile : Profile
    {
        public DtoActorProfile()
        {
            CreateMap<Proyecto2.Sakila.Model.MyModels.FilmActor, DtoModel.DtoActor>();
        }
    }
}
