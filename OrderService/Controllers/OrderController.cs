using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Mvc;
using OrderBDC.Interfaces;

namespace OrderService.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderBDC orderBDC;

        public OrderController(IOrderBDC orderBDC)
        {
            this.orderBDC = orderBDC;
        }

        [HttpGet("{id}")]
        public ActionResult<OrderDetails> GetAllOrdersOfUser([FromRoute] int id)
        {
            return orderBDC.GetAllOrdersOfUser(id);
        }
    }
}
