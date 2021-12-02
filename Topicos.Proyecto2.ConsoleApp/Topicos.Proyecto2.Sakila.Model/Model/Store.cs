using System;
using System.Collections.Generic;

#nullable disable

namespace Topicos.Proyecto2.Sakila.Model.Model
{
    public partial class Store
    {
        public Store()
        {
            Customers = new HashSet<Customer>();
        }

        public int StoreId { get; set; }
        public byte ManagerStaffId { get; set; }
        public int AddressId { get; set; }
        public DateTime LastUpdate { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
