using NUnit.Framework;
using System.Collections.Generic;
using System.Collections.Immutable;
using UnitOrderService;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGetTopBooksByOrders()
        {
            var dicOrders = new Dictionary<string, int>() { { "C# UnitTest", 1100 }, { "C# 5.0", 100 } };
            List<Order> orders = new List<Order>();
            orders.Add(new Order() { CustomerName = "James", Price = 1000, ProductName = "C# UnitTest", Type = "Book" });
            orders.Add(new Order() { CustomerName = "Gordon", Price = 100, ProductName = "C# UnitTest", Type = "Book" });
            orders.Add(new Order() { CustomerName = "Cynthia", Price = 100, ProductName = "C# 5.0", Type = "Book" });

            var stubOderService = new StubOderService();
            stubOderService.SetOrders(orders);

            OrderService orderService = stubOderService;


            Assert.AreEqual(orderService.GetTopBooksByOrders(), dicOrders.ToImmutableDictionary());
        }
    }
}