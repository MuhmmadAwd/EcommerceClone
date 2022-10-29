
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productsBrandRepo;
        private readonly IGenericRepository<ProductType> _productsTypeRepo;

        public ProductsController(IGenericRepository<Product> productsRepo,
            IGenericRepository<ProductBrand> productsBrandRepo,
            IGenericRepository<ProductType> productsTypeRepo)
        {
            _productsRepo = productsRepo;
            _productsTypeRepo = productsTypeRepo;
            _productsBrandRepo = productsBrandRepo;
        }

        public async Task<ActionResult<List<Product>>> GetProductList()
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();
            var Products = await _productsRepo.GetListAsync(spec);
            return Ok(Products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> getProduct(int id)
        {
            return await _productsRepo.GetByIdAsync(id);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> getProductBrandList()
        {
            return Ok(await _productsBrandRepo.GetListAllAsync());
        }
        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> getProductTypeList()
        {
            return Ok(await _productsTypeRepo.GetListAllAsync());
        }
    }
}