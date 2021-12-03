using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Topicos.Proyecto2.Api.Sakila.DTOModels
{
    public partial class DtoCountry
    {
        public short CountryId { get; set; }
        public string Country1 { get; set; }
        public virtual ICollection<DtoCity> Cities { get; set; }
    }
}
