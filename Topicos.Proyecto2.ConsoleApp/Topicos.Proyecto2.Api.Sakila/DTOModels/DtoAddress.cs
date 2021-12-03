using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Topicos.Proyecto2.Api.Sakila.DTOModels
{
    public partial class DtoAddress
    {
        public int AddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string District { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }


        //public virtual ICollection<Customer> Customers { get; set; }
        //public virtual ICollection<Store> Stores { get; set; }
    }
}
