using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topicos.Proyecto2.Sakila.Model.MyValidations;

namespace Topicos.Proyecto2.Sakila.Model.MyProperties
{
    [MetadataType(typeof(CustomerMetadata))]
    public partial class Customer
    {

        public class CustomerMetadata
        {
            [Required]
            public int CustomerId { get; set; }
            [Required]
            public int StoreId { get; set; }
            [MaxLength(45)]
            public string FirstName { get; set; }
            [MaxLength(45)]
            public string LastName { get; set; }
            [EmailAddress]
            public string Email { get; set; }
            [Required]
            public int AddressId { get; set; }
            public string Active { get; set; }
            [LeapYear()]
            public DateTime CreateDate { get; set; }
            public DateTime LastUpdate { get; set; }
        }

    }
}
