using System;
using System.Collections.Generic;

#nullable disable

namespace Topicos.Proyecto2.Sakila.Model.Model
{
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }

        public short CountryId { get; set; }
        public string Country1 { get; set; }
        public DateTime? LastUpdate { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
