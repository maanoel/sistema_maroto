using LojaVirtual.Business;
using LojaVirtual.Data.VO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tapioca.HATEOAS;

namespace LojaVirtual.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class ProductController : Controller
    {
        private IProductBusiness _productBusiness;

        public ProductController(IProductBusiness product) {
            _productBusiness = product;
        }

        [HttpPost]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult NovoProduto([FromBody]ProductVO product)
        {
            if (product == null) return BadRequest();
            return new OkObjectResult(_productBusiness.Create(product));
        }

        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult listarProdutos() {
            return new ObjectResult(_productBusiness.FindAll());
        }

        [HttpGet("id")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetProductById([FromQuery(Name = "id")] string id){
            return new ObjectResult(_productBusiness.FindById(Convert.ToInt32(id)));
        }

        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType(202)]
        [ProducesResponseType(204)]
        public IActionResult Put([FromBody] ProductVO product){
            
            if(product == null) return BadRequest();

            var updated = _productBusiness.Update(product);

            if(updated != null){
                return new OkObjectResult(updated);
            }else{
                return NotFound();
            }
        }   
   }
}
