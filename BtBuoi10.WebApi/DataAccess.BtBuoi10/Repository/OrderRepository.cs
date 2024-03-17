using DataAccess.BtBuoi10.Entities;
using DataAccess.BtBuoi10.EntityFramework;
using DataAccess.BtBuoi10.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.BtBuoi10.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private BtBuoi10DbContext dbContext;
        public OrderRepository(BtBuoi10DbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Order>> GetListOrder()
        {
            var list = new List<Order>();   
            try
            {
                list = dbContext.Order.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
            return list;
        }

        public async Task<ReturnData> OrderDelete(int id)
        {
            var returnData = new ReturnData();
            try
            {
                var list = dbContext.Order.ToList();
                var product = list.Where(s=>s.OrderID == id).FirstOrDefault();
                if(product == null)
                {
                    returnData.ReturnCode = -1;
                    returnData.ReturnMsg = "Sản phẩm không tồn tại";
                    return returnData;
                }
                dbContext.Order.Remove(product);
                dbContext.SaveChanges();
                returnData.ReturnCode = 1;
                returnData.ReturnMsg = "Xóa thành công";
                return returnData;
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public async Task<ReturnData> OrderInsertUpdate(Order order)
        {
            var returnData = new ReturnData();
            try
            {
                if(order.OrderID <= 0)
                {
                    dbContext.Add(order);
                    dbContext.SaveChanges();
                    returnData.ReturnCode = 1;
                    returnData.ReturnMsg = "Thêm thành công";
                    return returnData;
                }
                else {
                    dbContext.Update(order);
                    dbContext.SaveChanges();
                    returnData.ReturnCode = 1;
                    returnData.ReturnMsg = "Sửa thành công";
                    return returnData;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
