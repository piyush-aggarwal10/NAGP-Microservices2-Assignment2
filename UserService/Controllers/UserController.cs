using Common;
using Microsoft.AspNetCore.Mvc;
using UserBDC.Interfaces;

namespace UserService.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserBDC userBDC;
        public UserController(IUserBDC userBDC)
        {
            this.userBDC = userBDC;
        }

        [HttpGet("{id}")]
        public ActionResult<UserDTO> GetUserDetails([FromRoute] int id)
        {
            return userBDC.GetUserDetails(id);
        } 
    }
}
