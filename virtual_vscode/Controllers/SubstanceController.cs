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
    pegando a primeira parte do nome da classe em lower case [substance]Controller
    e expõe como endpoint REST
    */
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class SubstanceController : Controller
    {
        //Declaração do serviço usado
        private ISubstanceBusiness _substanceBusiness;

        /* Injeção de uma instancia de ISubstanceBusiness ao criar
        uma instancia de PersonController */
        public SubstanceController(ISubstanceBusiness substanceBusiness)
        {
            _substanceBusiness = substanceBusiness;
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/persons/v1/
        // [SwaggerResponse((202), Type = typeof(List<substance>))]
        // determina o objeto de retorno em caso de sucesso List<substance>
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 204, 400 e 401
        [HttpGet]
        [SwaggerResponse((200), Type = typeof(List<SubstanceVO>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        //[Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return new OkObjectResult(_substanceBusiness.FindAll());
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/persons/v1/
        // [SwaggerResponse((202), Type = typeof(List<substance>))]
        // determina o objeto de retorno em caso de sucesso List<substance>
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 204, 400 e 401
        [HttpGet("find-by-name")]
        [SwaggerResponse((200), Type = typeof(List<SubstanceVO>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetByName([FromQuery] string name)
        {
            return new OkObjectResult(_substanceBusiness.FindByName(name));
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/persons/v1/
        // [SwaggerResponse((202), Type = typeof(List<substance>))]
        // determina o objeto de retorno em caso de sucesso List<substance>
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 204, 400 e 401
        [HttpGet("find-with-paged-search/{sortDirection}/{pageSize}/{page}")]
        [SwaggerResponse((200), Type = typeof(List<SubstanceVO>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetPagedSearch([FromQuery] string name, string sortDirection, int pageSize, int page)
        {
            return new OkObjectResult(_substanceBusiness.FindWithPagedSearch(name, sortDirection, pageSize, page));
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/persons/v1/{id}
        // [SwaggerResponse((202), Type = typeof(substance))]
        // determina o objeto de retorno em caso de sucesso substance
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 204, 400 e 401
        [HttpGet("{id}")]
        [SwaggerResponse((200), Type = typeof(SubstanceVO))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
       // [Authorize("Bearer")] ACIONAR DEPOIS JWT
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var substance = _substanceBusiness.FindById(id);
            if (substance == null) return NotFound();
            return new OkObjectResult(substance);
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/
        // [SwaggerResponse((202), Type = typeof(substance))]
        // determina o objeto de retorno em caso de sucesso substance
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 400 e 401
        [HttpPost]
        [SwaggerResponse((201), Type = typeof(SubstanceVO))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody]SubstanceVO substance)
        {
            if (substance == null) return BadRequest();
            return new OkObjectResult(_substanceBusiness.Create(substance));
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/persons/v1/
        // determina o objeto de retorno em caso de sucesso substance
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 400 e 401
        [HttpPut]
        [SwaggerResponse((202), Type = typeof(SubstanceVO))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody]SubstanceVO substance)
        {
            if (substance == null) return BadRequest();
            var updatedPerson = _substanceBusiness.Update(substance);
            if (updatedPerson == null) return BadRequest();
            return new OkObjectResult(updatedPerson);
        }


        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/persons/v1/
        // determina o objeto de retorno em caso de sucesso substance
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 400 e 401
        [HttpPatch]
        [SwaggerResponse((202), Type = typeof(SubstanceVO))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Patch([FromBody]SubstanceVO substance)
        {
            if (substance == null) return BadRequest();
            var updatedPerson = _substanceBusiness.Update(substance);
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
            _substanceBusiness.Delete(id);
            return NoContent();
        }
    }
}
