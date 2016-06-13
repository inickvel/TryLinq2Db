using System;

namespace Vna.Linq2Db.ConsoleApp.Dto
{
    public class OrderDto
    {
        public int OrderID { get; set; }
        public string CustomerContactName { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}
