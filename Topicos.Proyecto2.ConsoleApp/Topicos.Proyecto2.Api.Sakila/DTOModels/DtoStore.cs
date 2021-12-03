using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Topicos.Proyecto2.Api.Sakila.DTOModels
{
    public partial class DtoStore
    {
        public int StoreId { get; set; }
        public byte ManagerStaffId { get; set; }

        //public virtual Address Address { get; set; }
        public virtual ICollection<DtoAddress> Address { get; set; }
        public virtual ICollection<DtoCustomer> Customers { get; set; }
       
    }
}
