using Common;

namespace UserBDC.Interfaces
{
    public interface IUserBDC
    {
        UserDTO GetUserDetails(int userId);
    }
}
