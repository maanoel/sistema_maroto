using Tapioca.HATEOAS;
using Microsoft.AspNetCore.Mvc;
using LojaVirtual.Business;
using LojaVirtual.Data.VO;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using LojaVirtual.Model;

namespace LojaVirtual.Controllers
{

    /* Mapeia as requisições de http://localhost:{porta}/api/persons/v1/
    Por padrão o ASP.NET Core mapeia todas as classes que extendem Controller
    pegando a primeira parte do nome da classe em lower case [user]Controller
    e expõe como endpoint REST
    */
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class UserController : Controller
    {
        //Declaração do serviço usado
        private IUserBusiness _userBusiness;

        /* Injeção de uma instancia de IUserBusiness ao criar
        uma instancia de PersonController */
        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/persons/v1/
        // [SwaggerResponse((202), Type = typeof(List<user>))]
        // determina o objeto de retorno em caso de sucesso List<user>
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 204, 400 e 401
        [HttpGet]
        [SwaggerResponse((200), Type = typeof(List<UserVO>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return new OkObjectResult(_userBusiness.FindAll());
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/persons/v1/
        // [SwaggerResponse((202), Type = typeof(List<user>))]
        // determina o objeto de retorno em caso de sucesso List<user>
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 204, 400 e 401
        [HttpGet("find-by-name")]
        [SwaggerResponse((200), Type = typeof(List<UserVO>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetByName([FromQuery] string firstName, [FromQuery] string lastName)
        {
            return new OkObjectResult(_userBusiness.FindByName(firstName, lastName));
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/persons/v1/
        // [SwaggerResponse((202), Type = typeof(List<user>))]
        // determina o objeto de retorno em caso de sucesso List<user>
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 204, 400 e 401
        [HttpGet("find-with-paged-search/{sortDirection}/{pageSize}/{page}")]
        [SwaggerResponse((200), Type = typeof(List<UserVO>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetPagedSearch([FromQuery] string name, string sortDirection, int pageSize, int page)
        {
            return new OkObjectResult(_userBusiness.FindWithPagedSearch(name, sortDirection, pageSize, page));
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/persons/v1/{id}
        // [SwaggerResponse((202), Type = typeof(user))]
        // determina o objeto de retorno em caso de sucesso user
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 204, 400 e 401
        [HttpGet("{id}")]
        [SwaggerResponse((200), Type = typeof(UserVO))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var user = _userBusiness.FindById(id);
            if (user == null) return NotFound();
            return new OkObjectResult(user);
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/
        // [SwaggerResponse((202), Type = typeof(user))]
        // determina o objeto de retorno em caso de sucesso user
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 400 e 401
        [HttpPost]
        [SwaggerResponse((201), Type = typeof(UserVO))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody]UserVO user)
        {
            if (user == null) return BadRequest();
            return new OkObjectResult(_userBusiness.Create(user));
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/persons/v1/
        // determina o objeto de retorno em caso de sucesso user
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 400 e 401
        [HttpPut]
        [SwaggerResponse((202), Type = typeof(UserVO))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody]UserVO user)
        {
            if (user == null) return BadRequest();
            var updatedPerson = _userBusiness.Update(user);
            if (updatedPerson == null) return BadRequest();
            return new OkObjectResult(updatedPerson);
        }


        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/persons/v1/
        // determina o objeto de retorno em caso de sucesso user
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 400 e 401
        [HttpPatch]
        [SwaggerResponse((202), Type = typeof(UserVO))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Patch([FromBody]UserVO user)
        {
            if (user == null) return BadRequest();
            var updatedPerson = _userBusiness.Update(user);
            if (updatedPerson == null) return BadRequest();
            return new OkObjectResult(updatedPerson);
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/persons/v1/{id}
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 400 e 401
        [HttpDelete("{id}")]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        [Authorize("Bearer")]
        public IActionResult Delete(int id)
        {
            _userBusiness.Delete(id);
            return NoContent();
        }
    }
}
