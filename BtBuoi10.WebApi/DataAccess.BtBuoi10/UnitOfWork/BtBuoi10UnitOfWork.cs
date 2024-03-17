using DataAccess.BtBuoi10.EntityFramework;
using DataAccess.BtBuoi10.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.BtBuoi10.UnitOfWork
{
    public class BtBuoi10UnitOfWork : IBtBuoi10UnitOfWork, IDisposable
    {
        public IOrderRepository orderRepository { get; set; }
        public IOrderDetailRepository orderDetailRepository { get; set; }
        public BtBuoi10DbContext btBuoi10DbContext { get; set; }
        public BtBuoi10UnitOfWork(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, BtBuoi10DbContext btBuoi10DbContext)
        {
            this.orderRepository = orderRepository;
            this.orderDetailRepository = orderDetailRepository;
            this.btBuoi10DbContext = btBuoi10DbContext;
        }

        public void SaveChange()
        {
            btBuoi10DbContext.SaveChanges();
        }

        public void Dispose()
        {
            btBuoi10DbContext.Dispose();
        }
    }
}
