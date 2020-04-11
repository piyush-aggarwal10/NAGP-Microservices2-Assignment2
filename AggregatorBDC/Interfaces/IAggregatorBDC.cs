using Common;

namespace AggregatorBDC.Interfaces
{
    public interface IAggregatorBDC
    {
        AggregatorDTO GetOrderDetails(int userId);
    }
}
