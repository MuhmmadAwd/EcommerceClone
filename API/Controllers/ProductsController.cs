
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productsBrandRepo;
        private readonly IGenericRepository<ProductType> _productsTypeRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productsRepo,
            IGenericRepository<ProductBrand> productsBrandRepo,
            IGenericRepository<ProductType> productsTypeRepo,
            IMapper mapper)
        {
            _productsRepo = productsRepo;
            _productsTypeRepo = productsTypeRepo;
            _mapper = mapper;
            _productsBrandRepo = productsBrandRepo;
        }

        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProductList(string sort)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(sort);

            var Products = await _productsRepo.GetListAsync(spec);

            return Ok(
                _mapper.Map<IReadOnlyList<Product>,
                IReadOnlyList<ProductToReturnDto>>(Products)
                );
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> getProduct(int id)
        {
            var product = await _productsRepo.GetByIdAsync(id);
            return _mapper.Map<Product, ProductToReturnDto>(product);
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