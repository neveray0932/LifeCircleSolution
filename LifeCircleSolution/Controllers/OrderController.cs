using LifeCircleSolution.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LifeCircleSolution
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ISingletonOrderService _singletonService;
        private readonly IScopeOrderService _scopedService;
        private readonly ITransientOrderService _transientService;

        public OrderController([FromServices] ISingletonOrderService singletonService, [FromServices] IScopeOrderService scopedService, [FromServices] ITransientOrderService transientService)
        {
            _singletonService = singletonService;
            _scopedService = scopedService;
            _transientService = transientService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            // 獲取服務的標識符
            var singletonId = _singletonService.GetId();
            var scopedId = _scopedService.GetId();
            var transientId = _transientService.GetId();

            // 返回結果
            return Ok(new
            {
                Singleton = singletonId,
                Scoped = scopedId,
                Transient = transientId
            });
        }
    }
}
