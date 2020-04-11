using AggregatorBDC.Interfaces;
using Common;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AggregatorBDC.Classes
{
    public class AggregatorBDC : IAggregatorBDC
    {
        public AggregatorDTO aggregateDetails;
        private string userServiceURL = Environment.GetEnvironmentVariable("USERSERVICE_URL") != null ? Environment.GetEnvironmentVariable("USERSERVICE_URL") : "http://custom_user:80";
        private string orderServiceURL = Environment.GetEnvironmentVariable("ORDERSERVICE_URL") != null ? Environment.GetEnvironmentVariable("ORDERSERVICE_URL") : "http://custom_order:80";

        public AggregatorBDC() {}

        public AggregatorDTO GetOrderDetails(int id)
        {
            UserDTO userDetailsReceived = GetUserData(id).GetAwaiter().GetResult();
            OrderDetails ordersReceived = GetOrdersOfUser().GetAwaiter().GetResult();

            aggregateDetails = new AggregatorDTO();
            aggregateDetails.UserDetails = userDetailsReceived;
            aggregateDetails.Orders = ordersReceived.orders;

            return aggregateDetails;
        }

        async Task<UserDTO> GetUserData(int id)
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage res = await client.GetAsync(userServiceURL + "/api/user/" + id))
            using (HttpContent content = res.Content)
            {
                UserDTO userDetailsReceived = await content.ReadAsAsync<UserDTO>();
                if (userDetailsReceived != null)
                {
                    return userDetailsReceived;
                }
                return null;
            }
        }

        async Task<OrderDetails> GetOrdersOfUser()
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage res = await client.GetAsync(orderServiceURL + "/api/orders/1"))
            using (HttpContent content = res.Content)
            {
                OrderDetails ordersReceived = await content.ReadAsAsync<OrderDetails>();
                if (ordersReceived != null)
                {
                    return ordersReceived;
                }
                return null;
            }
        }
    }
}
