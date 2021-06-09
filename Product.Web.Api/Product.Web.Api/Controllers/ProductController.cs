using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Web.Api.Models;
using Product.Web.Api.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<List<ProductModel>> Get()
        {
            return _productService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        public ActionResult<ProductModel> GetById(string id)
        {
            var product = _productService.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        public ActionResult<ProductModel> Create(ProductModel product)
        {
            _productService.Create(product);
            return CreatedAtRoute("GetProduct", new { id = product.Id.ToString() }, product);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, ProductModel productModel)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            _productService.Update(id, productModel);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult DeleteById(string id)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            _productService.Remove(product.Id);

            return NoContent();
        }

    }
}
