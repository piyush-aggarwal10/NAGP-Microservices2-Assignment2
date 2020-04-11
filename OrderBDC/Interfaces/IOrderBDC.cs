using Common;

namespace OrderBDC.Interfaces
{
    public interface IOrderBDC
    {
        OrderDetails GetAllOrdersOfUser(int userId);
    }
}
