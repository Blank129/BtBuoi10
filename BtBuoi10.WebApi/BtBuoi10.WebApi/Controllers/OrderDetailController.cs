using DataAccess.BtBuoi10.Entities;
using DataAccess.BtBuoi10.IRepository;
using DataAccess.BtBuoi10.Repository;
using DataAccess.BtBuoi10.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BtBuoi10.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        //private IOrderDetailRepository _orderDetailRepository;
        //public OrderDetailController(IOrderDetailRepository orderDetailRepository)
        //{
        //    _orderDetailRepository = orderDetailRepository;
        //}
        private IBtBuoi10UnitOfWork _unitOfWork;
        public OrderDetailController(IBtBuoi10UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("GetListOrderDetail")]
        public async Task<ActionResult> GetListOrderDetail()
        {
            var list = new List<OrderDetail>();
            list = await _unitOfWork.orderDetailRepository.GetListOrderDetail();
            return Ok(list);
        }
        [HttpPost("OrderDetailDelete")]
        public async Task<ActionResult> OrderDetailDelete(int id)
        {
            var returnData = new ReturnData();
            returnData = await _unitOfWork.orderDetailRepository.OrderDetailDelete(id);
            return Ok(returnData);
        }
        [HttpPost("OrderDetailInsertUpdate")]
        public async Task<ActionResult> OrderDetailInsertUpdate(OrderDetail orderDetail)
        {
            var returnData = new ReturnData();
            returnData = await _unitOfWork.orderDetailRepository.OrderDetailInsertUpdate(orderDetail);
            return Ok(returnData);
        }
    }
}
