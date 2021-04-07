using Asp.NetCoreBestPractices.Core.Models;
using Asp.NetCoreBestPractices.Core.Services;
using Asp.NetCoreBestPractices.Web.DTOs;
using Asp.NetCoreBestPractices.Web.Filters;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCoreBestPractices.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _mapper = mapper;
            _productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync();
            return View(_mapper.Map<IEnumerable<ProductDto>>(products));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            var newProduct = await _productService.AddAsync(_mapper.Map<Product>(productDto));
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            return View(_mapper.Map<ProductDto>(product));
        }
        [HttpPost]
        public IActionResult Update(ProductDto productDto)
        {
            var newProduct = _mapper.Map<Product>(productDto);
            _productService.Update(newProduct);
            return RedirectToAction("Index");
        }

        [ServiceFilter(typeof(ProductNotFoundFilter))]
        public IActionResult Delete(int id)
        {
            var deleteProduct = _productService.GetByIdAsync(id).Result;
            _productService.Remove(deleteProduct);
            return RedirectToAction("Index");
        }
        
    }
}
