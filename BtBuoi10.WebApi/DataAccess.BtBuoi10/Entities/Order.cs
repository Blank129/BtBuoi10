using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.BtBuoi10.Entities
{
    public class Order
    {
        public int OrderID {  get; set; }
        public string MaDonhang { get; set; }
        public int CustomerID { get; set; }
        public int TotalAmount { get; set; }
        public DateTime CreateDate { get; set; }
        public int Status { get; set; }
    }
}
