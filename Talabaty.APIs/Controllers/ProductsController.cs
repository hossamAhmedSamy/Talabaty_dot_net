using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Talabaty.APIs.DTOs;
using Talabaty.Core.Entity;
using Talabaty.Core.Repository;
using Talabaty.Core.specifcation;

namespace Talabaty.APIs.Controllers
{
   
    public class ProductsController : BaseController
    {
        private readonly IGenericRepository<Product> _ProductRepo;
        private readonly IMapper _mapper;
        public ProductsController(IGenericRepository<Product> ProductRepo , IMapper mapper) 
        {
            _ProductRepo = ProductRepo;
            _mapper = mapper;
        }
        // Change the return type of GetAllProducts to IActionResult
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var Spec= new ProductWithBrandAndTypeSpecification();
            var products = await _ProductRepo.GetAllWithSpecAsync(Spec);
            return Ok(products);
        }
        [HttpGet("{id}")]
/*        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            try
            {
                var Spec = new ProductWithBrandAndTypeSpecification(id);
                var Products = await _ProductRepo.GetByIdWithSpecAsync(Spec);
                var MappedProduct = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductToReturnDto>>((IEnumerable<Product>)Products);
                return Ok(MappedProduct);
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Product with ID {id} not found.");
            }
        }*/
        public async Task<ActionResult<ProductToReturnDto>> GetProductById(int id)
        {
            var spec = new ProductWithBrandAndTypeSpecification(id);
            var product = await _ProductRepo.GetByIdWithSpecAsync(spec);

            if (product == null)
                return NotFound($"Product with ID {id} not found.");

            var mappedProduct = _mapper.Map<Product, ProductToReturnDto>(product);
            return Ok(mappedProduct);
        }

    }
}