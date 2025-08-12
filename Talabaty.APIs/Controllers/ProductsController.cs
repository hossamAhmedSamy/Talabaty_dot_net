using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Talabaty.APIs.DTOs;
using Talabaty.APIs.Helpers;
using Talabaty.Core.Entity;
using Talabaty.Core.Repository;
using Talabaty.Core.specifcation;

namespace Talabaty.APIs.Controllers
{
   
    public class ProductsController : BaseController
    {
        private readonly IGenericRepository<Product> _ProductRepo;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<ProductType> _TypeRepo;
        private readonly IGenericRepository<ProductBrand> _BrandRepo;
        public ProductsController(IGenericRepository<Product> ProductRepo , IMapper mapper , IGenericRepository<ProductType> TypeRepo , IGenericRepository<ProductBrand> BrandRepo) 
        {
            _ProductRepo = ProductRepo;
            _mapper = mapper;
            _TypeRepo = TypeRepo;
            _BrandRepo = BrandRepo;
        }
        // Change the return type of GetAllProducts to IActionResult
        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetAllProducts([FromQuery] ProductSpecParams Params)
        {
            var Spec= new ProductWithBrandAndTypeSpecification(Params);
            var products = await _ProductRepo.GetAllWithSpecAsync(Spec);
            var ReturnedObject = new Pagination<ProductToReturnDto>()
            {
                PageSize = Params.PageSize,
                PageIndex = Params.PageIndex,
                Data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>((IReadOnlyList<Product>)products)
            };
            return Ok(ReturnedObject);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProductById(int id)
        {
            var spec = new ProductWithBrandAndTypeSpecification(id);
            var product = await _ProductRepo.GetByIdWithSpecAsync(spec);

            if (product == null)
                return NotFound($"Product with ID {id} not found.");

            var mappedProduct = _mapper.Map<Product, ProductToReturnDto>(product);
            return Ok(mappedProduct);
        }
        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<ProductType>>> GetTypes()
        {
            var types = await _TypeRepo.GetAllAsync(); 
            return Ok(types);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<ProductType>>> GetBrands()
        {
            var Brands= await _BrandRepo.GetAllAsync();
            return Ok(Brands);
        }
    }
}