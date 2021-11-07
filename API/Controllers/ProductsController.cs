using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Data;
using Domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Core.Interfaces;
using Core.Specifications.SpecModels;
using Core.Mediatr.Products.Queries.ProductDetails;
using MediatR;
using AutoMapper;
using Core.Mediatr.Products.Queries.ProductList;
using API.Models.Product;
using Core.Mediatr.Products.Commands.CreateProduct;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _brandRepo;
        private readonly IGenericRepository<ProductType> _typeRepo;

        public ProductsController(
            IMapper mapper,
            IGenericRepository<Product> productRepo,
            IGenericRepository<ProductBrand> brandRepo,
            IGenericRepository<ProductType> typeRepo)
        {
            _typeRepo = typeRepo;
            _brandRepo = brandRepo;
            _mapper = mapper;
            _productRepo = productRepo;
        }
        [HttpGet]
        public async Task<ActionResult<ProductListVm>> GetProducts()
        {
            
            // var spec = new ProductsWithTypesAndBrandsSpecification();
            // var products = await _productRepo.ListAsync(spec);
            // return Ok(products);

             var query = new ProductListQuery{};
            var vm = await Mediator.Send(query);
            return Ok(vm);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetailsVm>> GetProduct(Guid id)
        {
        //     var spec = new ProductsWithTypesAndBrandsSpecification(id);
        //    return await _productRepo.GetEntityWithSpec(spec);

            var query = new ProductDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _brandRepo.ListAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _typeRepo.ListAllAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateProductDto createProcuctDto)
        {
            var command = _mapper.Map<CreateProductCommand>(createProcuctDto);
           var productId = await Mediator.Send(command);
            return Ok(productId);
        }

        
    }

}