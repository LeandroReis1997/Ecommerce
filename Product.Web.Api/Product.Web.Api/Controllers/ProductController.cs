using Microsoft.AspNetCore.Mvc;
using Product.Web.Bll.Interface;
using Product.Web.Info;
using System.Collections.Generic;

namespace Product.Web.Api.Controllers
{
    [Route("webapi/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductBll bll;

        public ProductController(IProductBll productBll)
        {
            bll = productBll;
        }

        [HttpGet]
        public IList<ProductInfo> Get()
        {
            return bll.GetAllProducts();
        }

        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        public IActionResult GetById(string id)
        {
            var product = bll.GetByProductId(id);

            if (product == null)
            {
                return NotFound();
            }

            return new ObjectResult(product);
        }

        [HttpPost]
        public ActionResult<ProductInfo> Create(ProductInfo product)
        {
            bll.AddProduct(product);
            return CreatedAtRoute("GetProduct", new { id = product.Id.ToString() }, product);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, ProductInfo productModel)
        {
            var product = bll.GetByProductId(id);
            if (product == null)
            {
                return NotFound();
            }

            bll.EditProduct(id, productModel);

            return new ObjectResult(product);
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

            return new ObjectResult(product);
        }

    }
}
