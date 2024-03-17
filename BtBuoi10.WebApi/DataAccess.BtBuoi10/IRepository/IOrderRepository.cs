using DataAccess.BtBuoi10.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.BtBuoi10.IRepository
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetListOrder();
        Task<ReturnData> OrderDelete(int id);
        Task<ReturnData> OrderInsertUpdate(Order order);

    }
}
