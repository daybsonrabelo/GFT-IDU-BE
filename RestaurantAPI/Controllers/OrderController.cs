using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private OrderRepository _orderRepository;

        public OrderController(ILogger<OrderController> logger, OrderRepository orderRepository)
        {
            _logger = logger;
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            // orderList.Add(new Order() {
            //     Input = "morning, 1, 2, 3",
            //     Output = "eggs, toast, coffee"
            // });
            return _orderRepository.GetOrders();
        }

        [HttpPost]
        public Order Insert(InputOrder inputOrder)
        {
            OrderService service = new OrderService();
            Order order = service.GenerateOrder(inputOrder.Input);
            _orderRepository.AddOrder(order);
            return order;
        }
    }
}
