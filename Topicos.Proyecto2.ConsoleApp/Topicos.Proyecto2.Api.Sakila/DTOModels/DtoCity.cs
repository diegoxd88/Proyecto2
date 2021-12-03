using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Topicos.Proyecto2.Api.Sakila.DTOModels
{
    public partial class DtoCity
    {
        public int CityId { get; set; }
        public string City1 { get; set; }

        //public virtual Country Country { get; set; }
        public virtual ICollection<DtoAddress> Addresses { get; set; }
    }
}
