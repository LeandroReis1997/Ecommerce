using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Product.Web.Api.DTO.Product;
using Product.Web.Bll.Interface;
using Product.Web.Info;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Product.Web.Api.Controllers
{
    [Route("webapi/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductBll bll;
        private readonly IMapper _mapper;

        public ProductController(IProductBll productBll, IMapper mapper)
        {
            bll = productBll;
            _mapper = mapper;
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<ProductListDTO>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(IEnumerable<ProductListDTO>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(ProductListDTO))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<IList<ProductListDTO>>(bll.GetAllProducts()));
        }

        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        [Produces(typeof(IEnumerable<ProductListDTO>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(ProductListDTO))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IActionResult GetById(string id)
        {
            var product = bll.GetByProductId(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProductListDTO>(bll.GetByProductId(id)));
        }

        [HttpGet("{name}")]
        [Produces(typeof(IEnumerable<ProductListDTO>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(ProductListDTO))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IActionResult GetByName(string name)
        {
            var product = bll.GetByName(name);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<ProductListDTO>>(bll.GetByName(name)));
        }

        [HttpPost]
        [Produces(typeof(ProductDTO))]
        [SwaggerResponse((int)HttpStatusCode.Created, Description = "Inserido com sucesso", Type = typeof(ProductDTO))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> Create(ProductDTO product)
        {
            var productDTO = await bll.AddProductAsync(_mapper.Map<ProductInfo>(product));

            return CreatedAtRoute("GetProduct", new { id = productDTO.Id.ToString() }, productDTO);
        }

        [HttpPut("{id:length(24)}")]
        [Produces(typeof(ProductDTO))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Alterado com sucesso", Type = typeof(ProductDTO))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> Update(string id, ProductDTO productDTO)
        {
            var product = bll.GetByProductId(id);

            if (product == null)
            {
                return NotFound();
            }

            var productObject = await bll.EditProductAsync(id, _mapper.Map<ProductInfo>(productDTO));

            return new ObjectResult(_mapper.Map<ProductInfo>(productObject));
        }

        [HttpDelete("{id:length(24)}")]
        [Produces(typeof(OkResult))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Removido com sucesso")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IActionResult DeleteById(string id)
        {
            var product = bll.GetByProductId(id);

            if (product == null)
            {
                return NotFound();
            }

            bll.DeleteProduct(product.Id);

            return new ObjectResult(_mapper.Map<ProductInfo>(product));
        }

    }
}
