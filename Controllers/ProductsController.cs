using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.BLL.Helper;
using Talabat.BLL.Interfaces;
using Talabat.BLL.Specifications;
using Talabat.DAL.Entities;

namespace Talabat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IGenericRepository<Product> prodRepo;
        private readonly IGenericRepository<ProductBrand> _BrandRepo;
        private readonly IGenericRepository<ProductType> _PrdTypeRepo;
        
        private readonly IMapper _mapper;
        public ProductsController(IGenericRepository<Product> prodRepo, IMapper mapper, IGenericRepository<ProductBrand> brandRepo = null, IGenericRepository<ProductType> prdTypeRepo = null)
        {
            this.prodRepo = prodRepo;
            _mapper = mapper;
            _BrandRepo = brandRepo;
            _PrdTypeRepo = prdTypeRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<GetProductsDto>>> GetAll()
        {
            var Products = await prodRepo.GetAll();
            var result = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<GetProductsDto>>(Products);
            return Ok(result);
        }

        [HttpGet("GetAllWithSpecs")]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetAllWithSpecs()
        {
            var Products = await prodRepo.GetAllWithSpecs(new ProductWithTypeandBrandSpecification());
            var result =  _mapper.Map<IReadOnlyList<Product> ,  IReadOnlyList<GetProductsDto>>(Products);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<GetProductsDto>> GetWithId(int Id)
        {
            var Spec = new ProductWithTypeandBrandSpecification(Id);
            var Product = await prodRepo.GetWithSpecs(Spec);
            var result = _mapper.Map<Product, GetProductsDto>(Product);
            return Ok(result); 
        }

        [HttpGet("GetAllBrands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetBrands()
        {
            var brands = await _BrandRepo.GetAll();
            return Ok(brands);
        }

        [HttpGet("GetAllTypes")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetAllType()
        {
            var prodTypes = await _PrdTypeRepo.GetAll();
            return Ok(prodTypes);
        }
    }
}
