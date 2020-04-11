using Common;
using OrderBDC.Interfaces;
using System.Collections.Generic;

namespace OrderBDC.Classes
{
    public class OrderBDC: IOrderBDC
    {
        OrderDetails orderDetails;
        public OrderBDC()
        {
            CreateDummyOrdersList();
        }

        public void CreateDummyOrdersList()
        {
            OrderDTO order1 = new OrderDTO
            {
                OrderId = 1,
                OrderAmount = 250,
                OrderDate = "14-Apr-2020"
            };

            OrderDTO order2 = new OrderDTO
            {
                OrderId = 2,
                OrderAmount = 450,
                OrderDate = "15-Apr-2020"
            };


            orderDetails = new OrderDetails();
            orderDetails.orders = new List<OrderDTO>() { order1, order2 };
        }

        public OrderDetails GetAllOrdersOfUser(int userId)
        {
            return orderDetails;
        }
    }
}
