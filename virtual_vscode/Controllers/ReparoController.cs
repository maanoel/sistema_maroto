using Tapioca.HATEOAS;
using Microsoft.AspNetCore.Mvc;
using LojaVirtual.Business;
using LojaVirtual.Data.VO;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace LojaVirtual.Controllers
{

    /* Mapeia as requisições de http://localhost:{porta}/api/Reparos/v1/
    Por padrão o ASP.NET Core mapeia todas as classes que extendem Controller
    pegando a primeira parte do nome da classe em lower case [Reparo]Controller
    e expõe como endpoint REST
    */
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class ReparoController : Controller
    {
        //Declaração do serviço usado
        private IReparoBusiness _reparoBusiness;

        /* Injeção de uma instancia de IReparoBusiness ao criar
        uma instancia de ReparoController */
        public ReparoController(IReparoBusiness ReparoBusiness)
        {
            _reparoBusiness = ReparoBusiness;
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/Reparos/v1/{id}
        // [SwaggerResponse((202), Type = typeof(Reparo))]
        // determina o objeto de retorno em caso de sucesso Reparo
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 204, 400 e 401
         [HttpPost]
        [SwaggerResponse((201), Type = typeof(ReparoVO))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody]ReparoVO reparo)
        {
            if (reparo == null) return BadRequest();
            return new OkObjectResult(_reparoBusiness.Create(reparo));
        }

         // Configura o Swagger para a operação
        // http://localhost:{porta}/api/Reparos/v1/{id}
        // [SwaggerResponse((202), Type = typeof(Reparo))]
        // determina o objeto de retorno em caso de sucesso Reparo
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 204, 400 e 401
        [HttpGet]
        [HttpOptions]
        [SwaggerResponse((200), Type = typeof(ReparoVO))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            var Reparo = _reparoBusiness.FindAll();
            if (Reparo == null) return NotFound();
            return new OkObjectResult(Reparo);
        }

         // Configura o Swagger para a operação
        // http://localhost:{porta}/api/Reparos/v1/{id}
        // [SwaggerResponse((202), Type = typeof(Reparo))]
        // determina o objeto de retorno em caso de sucesso Reparo
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 204, 400 e 401
        [HttpPost("PostBase64")]
        [HttpOptions]
        [SwaggerResponse((200), Type = typeof(string))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<string> PostBase64() 
        {
            
            var filePath = System.IO.Path.GetTempFileName();

            var file = Request.Form.Files[0];

         
            using (var stream = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
            {
                await file.CopyToAsync(stream);

                return Convert.ToString(file.Length);
            }
        }
           
    }
}
