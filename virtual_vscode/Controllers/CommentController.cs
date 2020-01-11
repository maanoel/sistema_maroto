using Tapioca.HATEOAS;
using Microsoft.AspNetCore.Mvc;
using LojaVirtual.Business;
using LojaVirtual.Data.VO;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using LojaVirtual.Model;
using System;

namespace LojaVirtual.Controllers
{

    /* Mapeia as requisições de http://localhost:{porta}/api/persons/v1/
    Por padrão o ASP.NET Core mapeia todas as classes que extendem Controller
    pegando a primeira parte do nome da classe em lower case [comments]Controller
    e expõe como endpoint REST
    */
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class CommentController : Controller
    {
        //Declaração do serviço usado
        private ICommentBusiness _commentsBusiness;

        /* Injeção de uma instancia de ICommentBusiness ao criar
        uma instancia de PersonController */
        public CommentController(ICommentBusiness commentsBusiness)
        {
            _commentsBusiness = commentsBusiness;
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/persons/v1/
        // [SwaggerResponse((202), Type = typeof(List<comments>))]
        // determina o objeto de retorno em caso de sucesso List<comments>
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 204, 400 e 401
        [HttpGet]
        [SwaggerResponse((200), Type = typeof(List<CommentVO>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        //[Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return new OkObjectResult(_commentsBusiness.FindAll());
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/persons/v1/
        // [SwaggerResponse((202), Type = typeof(List<comments>))]
        // determina o objeto de retorno em caso de sucesso List<comments>
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 204, 400 e 401
        [HttpGet("find-by-name")]
        [SwaggerResponse((200), Type = typeof(List<CommentVO>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetById([FromQuery] string id)
        {
            return new OkObjectResult(_commentsBusiness.FindById(Convert.ToInt32(id)));
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/persons/v1/
        // [SwaggerResponse((202), Type = typeof(List<comments>))]
        // determina o objeto de retorno em caso de sucesso List<comments>
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 204, 400 e 401
        [HttpGet("find-with-paged-search/{sortDirection}/{pageSize}/{page}")]
        [SwaggerResponse((200), Type = typeof(List<CommentVO>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetPagedSearch([FromQuery] string name, string sortDirection, int pageSize, int page)
        {
            return new OkObjectResult(_commentsBusiness.FindWithPagedSearch(name, sortDirection, pageSize, page));
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/persons/v1/{id}
        // [SwaggerResponse((202), Type = typeof(comments))]
        // determina o objeto de retorno em caso de sucesso comments
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 204, 400 e 401
        [HttpGet("{id}")]
        [SwaggerResponse((200), Type = typeof(CommentVO))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
       // [Authorize("Bearer")] ACIONAR DEPOIS JWT
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var comments = _commentsBusiness.FindById(id);
            if (comments == null) return NotFound();
            return new OkObjectResult(comments);
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/
        // [SwaggerResponse((202), Type = typeof(comments))]
        // determina o objeto de retorno em caso de sucesso comments
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 400 e 401
        [HttpPost]
        [SwaggerResponse((201), Type = typeof(CommentVO))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody]CommentVO comments)
        {
            if (comments == null) return BadRequest();
            return new OkObjectResult(_commentsBusiness.Create(comments));
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/persons/v1/
        // determina o objeto de retorno em caso de sucesso comments
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 400 e 401
        [HttpPut]
        [SwaggerResponse((202), Type = typeof(CommentVO))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody]CommentVO comments)
        {
            if (comments == null) return BadRequest();
            var updatedPerson = _commentsBusiness.Update(comments);
            if (updatedPerson == null) return BadRequest();
            return new OkObjectResult(updatedPerson);
        }


        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/persons/v1/
        // determina o objeto de retorno em caso de sucesso comments
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 400 e 401
        [HttpPatch]
        [SwaggerResponse((202), Type = typeof(CommentVO))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Patch([FromBody]CommentVO comments)
        {
            if (comments == null) return BadRequest();
            var updatedPerson = _commentsBusiness.Update(comments);
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
            _commentsBusiness.Delete(id);
            return NoContent();
        }
    }
}
