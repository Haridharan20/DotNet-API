using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPI.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        [Route("User/hello")]
        public string Index()
        {
            return "Hello world";
        }

        [Route("User/getUserByID/{Id}")]
        public string GetUserNameByID(int Id)
        {
            if(Id==1)
            {
                return "first user";
            }
            else
            {
                return "User not";
            }
        }
    }
}
