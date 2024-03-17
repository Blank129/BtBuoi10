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
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private BtBuoi10DbContext dbContext;
        public OrderDetailRepository(BtBuoi10DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<OrderDetail>> GetListOrderDetail()
        {
            var list = new List<OrderDetail>();
            try
            {
                list = dbContext.OrderDetail.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
            return list;
        }

        public async Task<ReturnData> OrderDetailDelete(int id)
        {
            var returnData = new ReturnData();
            try
            {
                var list = dbContext.OrderDetail.ToList();
                var product = list.Where(s => s.OrderID == id).FirstOrDefault();
                if (product == null)
                {
                    returnData.ReturnCode = -1;
                    returnData.ReturnMsg = "Sản phẩm không tồn tại";
                    return returnData;
                }
                dbContext.OrderDetail.Remove(product);
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

        public async Task<ReturnData> OrderDetailInsertUpdate(OrderDetail orderDetail)
        {
            var returnData = new ReturnData();
            try
            {
                if (orderDetail.OrderDetailID <= 0)
                {
                    dbContext.Add(orderDetail);
                    dbContext.SaveChanges();
                    returnData.ReturnCode = 1;
                    returnData.ReturnMsg = "Thêm thành công";
                    return returnData;
                }
                else
                {
                    dbContext.Update(orderDetail);
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
