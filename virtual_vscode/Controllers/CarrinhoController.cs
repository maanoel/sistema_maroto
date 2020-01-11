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

    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class CarrinhoController : Controller
    {
       
        private ICarrinhoBusiness _carrinhoBusiness;

        public CarrinhoController(ICarrinhoBusiness carrinho)
        {
            _carrinhoBusiness = carrinho;
        }

       
        [HttpPost]
        [SwaggerResponse((202), Type = typeof(Carrinho))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody]Carrinho carrinho)
        {
            if (carrinho == null) return BadRequest();
            var updatedCarrinho= _carrinhoBusiness.Create(carrinho);
            if (updatedCarrinho == null) return BadRequest();
            return new OkObjectResult(updatedCarrinho);
        }

        [HttpPut]
        [SwaggerResponse((202), Type = typeof(Carrinho))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody]Carrinho carrinho)
        {
            if (carrinho == null) return BadRequest();
            var updatedCarrinho= _carrinhoBusiness.Update(carrinho);
            if (updatedCarrinho == null) return BadRequest();
            return new OkObjectResult(updatedCarrinho);
        }
        

    }
}
