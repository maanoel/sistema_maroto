using Tapioca.HATEOAS;
using Microsoft.AspNetCore.Mvc;
using LojaVirtual.Business;
using LojaVirtual.Data.VO;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace LojaVirtual.Controllers
{

    /* Mapeia as requisições de http://localhost:{porta}/api/pessoas/v1/
    Por padrão o ASP.NET Core mapeia todas as classes que extendem Controller
    pegando a primeira parte do nome da classe em lower case [pessoa]Controller
    e expõe como endpoint REST
    */
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PessoaController : Controller
    {
        //Declaração do serviço usado
        private IPessoaBusiness _pessoaBusiness;

        /* Injeção de uma instancia de IPessoaBusiness ao criar
        uma instancia de pessoaController */
        public PessoaController(IPessoaBusiness pessoaBusiness)
        {
            _pessoaBusiness = pessoaBusiness;
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/pessoas/v1/{id}
        // [SwaggerResponse((202), Type = typeof(pessoa))]
        // determina o objeto de retorno em caso de sucesso pessoa
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 204, 400 e 401
        [HttpGet("{id}")]
        [HttpOptions]
        [SwaggerResponse((200), Type = typeof(PessoaVO))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(string id)
        {
            var pessoa = _pessoaBusiness.FindById(id);
            if (pessoa == null) return NotFound();
            return new OkObjectResult(pessoa);
        }
    }
}
