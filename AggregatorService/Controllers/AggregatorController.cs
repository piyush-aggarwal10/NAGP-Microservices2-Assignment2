using AggregatorBDC.Interfaces;
using Common;
using Microsoft.AspNetCore.Mvc;

namespace AggregatorService.Controllers
{
    [Route("api/orderdetails")]
    [ApiController]
    public class AggregatorController : ControllerBase
    {
        private IAggregatorBDC aggregatorBDC;

        public AggregatorController(IAggregatorBDC aggregatorBDC)
        {
            this.aggregatorBDC = aggregatorBDC;
        }

        [HttpGet("{id}")]
        public ActionResult<AggregatorDTO> GetOrderDetails([FromRoute] int id)
        {
            return aggregatorBDC.GetOrderDetails(id);
        }
    }
}
