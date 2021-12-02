using System;
using System.Collections.Generic;

#nullable disable

namespace Topicos.Proyecto2.Sakila.Model.MyModels
{
    public partial class FilmCategory
    {
        public int FilmId { get; set; }
        public byte CategoryId { get; set; }
        public DateTime LastUpdate { get; set; }

        public virtual Film Film { get; set; }
    }
}
