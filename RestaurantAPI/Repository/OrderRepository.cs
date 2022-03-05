using System;
using System.Collections.Generic;

namespace RestaurantAPI{
    public class OrderRepository {

        private List<Order> orderList;

        public OrderRepository() {
            if (orderList == null)
                orderList = new List<Order>();
        }
        
        public List<Order> GetOrders() {
            return orderList;
        }

        public void AddOrder(Order order) {
            orderList.Add(order);
        }
    }
}