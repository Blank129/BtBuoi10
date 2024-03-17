using DataAccess.BtBuoi10.Entities;
using DataAccess.BtBuoi10.IRepository;
using DataAccess.BtBuoi10.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BtBuoi10.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        //private IOrderRepository orderRepository;
        //public OrderController(IOrderRepository orderRepository)
        //{
        //    this.orderRepository = orderRepository;
        //}
        private IBtBuoi10UnitOfWork _unitOfWork;
        public OrderController(IBtBuoi10UnitOfWork btBuoi10UnitOfWork)
        {
            _unitOfWork = btBuoi10UnitOfWork;
        }
        [HttpPost("GetListOrder")]
        public async Task<ActionResult> GetListOrder()
        {
            var list = new List<Order>();
            list = await _unitOfWork.orderRepository.GetListOrder();
            return Ok(list);
        }
        [HttpPost("OrderDelete")]
        public async Task<ActionResult> OrderDelete(int id)
        {
            var returnData = new ReturnData();
            returnData = await _unitOfWork.orderRepository.OrderDelete(id);
            return Ok(returnData);
        }
        [HttpPost("OrderInsertUpdate")]
        public async Task<ActionResult> OrderInsertUpdate(Order order)
        {
            var returnData = new ReturnData();
            returnData = await _unitOfWork.orderRepository.OrderInsertUpdate(order);
            return Ok(returnData);
        }
    }
}
