using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Topicos.Proyecto2.Api.Sakila.DTOModels
{
    public partial class DtoCustomer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Active { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<DtoAddress> Address { get; set; }

        //public virtual Address Address { get; set; }
    }
}
