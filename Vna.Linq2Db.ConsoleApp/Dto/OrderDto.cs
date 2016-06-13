using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Vna.Linq2Db.ConsoleApp.Dto
{
    public class OrderDto
    {
        public int OrderID { get; set; }

        public short Quantity { get; set; }

        public string OrderDetailsOrderCustomerContactName { get; set; }

        public DateTime? OrderDetailsOrderOrderDate { get; set; }

        public string OrderDetailsProductProductName { get; set; }

        [IgnoreMap]
        public ICollection<int> BasinIds { get; set; }
    }
}
