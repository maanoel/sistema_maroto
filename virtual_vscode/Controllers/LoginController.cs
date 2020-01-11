using Microsoft.AspNetCore.Mvc;
using LojaVirtual.Business;
using Microsoft.AspNetCore.Authorization;
using LojaVirtual.Model;

namespace LojaVirtual.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class LoginController : Controller
    {
        private ILoginBusiness _loginBusiness;

        public LoginController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }

        [AllowAnonymous]
        [HttpPost]
        public object Post([FromBody]UserVO user)
        {
            if (user == null) return BadRequest();
            return _loginBusiness.FindByLogin(user);
        }

        [AllowAnonymous]
        [HttpPost("new_user")]
        public object NewUser([FromBody]UserVO user)
        {
            if (user == null) return BadRequest();

           return _loginBusiness.CreateUser(user);
        }


    }
}
