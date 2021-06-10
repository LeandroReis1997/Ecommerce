using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Product.Web.Api.DTO.Product;
using Product.Web.Bll.Interface;
using Product.Web.Info;
using System.Collections.Generic;
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
        public IActionResult Get()
        {
            return Ok(_mapper.Map<IList<ProductListDTO>>(bll.GetAllProducts()));
        }

        [HttpGet("{id:length(24)}", Name = "GetProduct")]
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
        public IActionResult GetByName(string name)
        {
            var product = bll.GetByName(name);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(bll.GetByName(name));
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO product)
        {
            var productDTO = await bll.AddProductAsync(_mapper.Map<ProductInfo>(product));

            return CreatedAtRoute("GetProduct", new { id = productDTO.Id.ToString() }, productDTO);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, ProductDTO productDTO)
        {
            var product = bll.GetByProductId(id);
            
            if (product == null)
            {
                return NotFound();
            }

            await bll.EditProductAsync(id, _mapper.Map<ProductInfo>(productDTO));

            return new ObjectResult(_mapper.Map<ProductInfo>(product));
        }

        [HttpDelete("{id:length(24)}")]
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
