using Tapioca.HATEOAS;
using Microsoft.AspNetCore.Mvc;
using LojaVirtual.Business;
using LojaVirtual.Data.VO;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace LojaVirtual.Controllers
{

    /* Mapeia as requisições de http://localhost:{porta}/api/Imovels/v1/
    Por padrão o ASP.NET Core mapeia todas as classes que extendem Controller
    pegando a primeira parte do nome da classe em lower case [Imovel]Controller
    e expõe como endpoint REST
    */
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class ImovelController : Controller
    {
        //Declaração do serviço usado
        private IImovelBusiness _ImovelBusiness;

        /* Injeção de uma instancia de IImovelBusiness ao criar
        uma instancia de ImovelController */
        public ImovelController(IImovelBusiness ImovelBusiness)
        {
            _ImovelBusiness = ImovelBusiness;
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/Imovels/v1/{id}
        // [SwaggerResponse((202), Type = typeof(Imovel))]
        // determina o objeto de retorno em caso de sucesso Imovel
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 204, 400 e 401
        [HttpGet("{id}")]
        [HttpOptions]
        [SwaggerResponse((200), Type = typeof(ImovelVO))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(string id)
        {
            var Imovel = _ImovelBusiness.FindById(id);
            if (Imovel == null) return NotFound();
            return new OkObjectResult(Imovel);
        }
    }
}
