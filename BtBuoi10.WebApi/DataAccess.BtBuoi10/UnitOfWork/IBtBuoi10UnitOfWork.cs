using DataAccess.BtBuoi10.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.BtBuoi10.UnitOfWork
{
    public interface IBtBuoi10UnitOfWork
    {
        public IOrderRepository orderRepository { get; set; }
        public IOrderDetailRepository orderDetailRepository { get; set; }
        void SaveChange();
    }
}
