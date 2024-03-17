using DataAccess.BtBuoi10.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.BtBuoi10.IRepository
{
    public interface IOrderDetailRepository
    {
        Task<List<OrderDetail>> GetListOrderDetail();
        Task<ReturnData> OrderDetailDelete(int id);
        Task<ReturnData> OrderDetailInsertUpdate(OrderDetail orderDetail);
    }
}
