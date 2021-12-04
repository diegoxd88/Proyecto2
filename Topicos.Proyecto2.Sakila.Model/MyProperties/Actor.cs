using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topicos.Proyecto2.Sakila.Model.MyValidations;

namespace Topicos.Proyecto2.Sakila.Model.MyModels
{
    [MetadataType(typeof(ActorMetadata))]
    public partial class Actor
    {
        [NotMapped]
        public string FullName
        {
            get
            {
                var firstName = this.FirstName + " ";

                var lastName = string.Empty;
                if (this.LastName != null)
                {
                    lastName = this.LastName;
                }

                var resultado = $"{firstName}{lastName}";
                return resultado;
            }
            set { }
        }

        public class ActorMetadata
        {
            [Required]
            public int ActorId { get; set; }
            [MaxLength(30)]
            public string FirstName { get; set; }
            [MaxLength(30)]
            public string LastName { get; set; }
            [LeapYear]
            public DateTime LastUpdate { get; set; }
        }

    }
}
