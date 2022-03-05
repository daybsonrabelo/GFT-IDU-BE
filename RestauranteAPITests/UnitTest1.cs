using System;
using Xunit;
using RestaurantAPI;
using System.Collections.Generic;

namespace RestauranteAPITests
{
    public class UnitTest1
    {
        [Fact]
        public void TestRemoveEndComma1()
        {
            var service = new OrderService();
            string ret = service.RemoveEndComma("1, 3, 5, ");
            Assert.Equal("1, 3, 5", ret);
        }

        [Fact]
        public void TestRemoveEndComma2()
        {
            var service = new OrderService();
            string ret = service.RemoveEndComma("1, 3, 5, 4");
            Assert.Equal("1, 3, 5, 4", ret);
        }

        [Fact]
        public void TestGenerateOutput()
        {
            var service = new OrderService();
            List<string> testList = new List<string>(){"morning", "1", "1", "2", "3"};
            
            string ret = service.GenerateOutput(testList);
            Assert.Equal("eggs, error", ret);
        }

        [Fact]
        public void TestGenerateOrder()
        {
            var service = new OrderService();
            string input = "night, 1, 2, 3, 4";
            
            Order order = service.GenerateOrder(input);
            Assert.Equal("steak, potato, wine, cake", order.Output);
        }

        [Fact]
        public void TestGenerateOrderWithError()
        {
            var service = new OrderService();
            string input = "night, 1, 2, 3, 5";
            
            Order order = service.GenerateOrder(input);
            Assert.Equal("steak, potato, wine, error", order.Output);
        }
    }
}
