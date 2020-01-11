using Tapioca.HATEOAS;
using Microsoft.AspNetCore.Mvc;
using LojaVirtual.Business;
using LojaVirtual.Data.VO;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace LojaVirtual.Controllers
{

    /* Mapeia as requisições de http://localhost:{porta}/api/Boletos/v1/
    Por padrão o ASP.NET Core mapeia todas as classes que extendem Controller
    pegando a primeira parte do nome da classe em lower case [Boleto]Controller
    e expõe como endpoint REST
    */
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BoletoController : Controller
    {
        //Declaração do serviço usado
        private IBoletoBusiness _BoletoBusiness;

        /* Injeção de uma instancia de IBoletoBusiness ao criar
        uma instancia de BoletoController */
        public BoletoController(IBoletoBusiness BoletoBusiness)
        {
            _BoletoBusiness = BoletoBusiness;
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/Boletos/v1/{id}
        // [SwaggerResponse((202), Type = typeof(Boleto))]
        // determina o objeto de retorno em caso de sucesso Boleto
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 204, 400 e 401
        [HttpGet("{id}")]
        [HttpOptions]
        [SwaggerResponse((200), Type = typeof(BoletoVO))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(int id)
        {
            var Boleto = _BoletoBusiness.FindById(id);
            if (Boleto == null) return NotFound();
            return new OkObjectResult(Boleto);
        }
    }
}
