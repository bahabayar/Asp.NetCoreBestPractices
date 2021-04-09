using Asp.NetCoreBestPractices.Core.Models;
using Asp.NetCoreBestPractices.Core.Services;
using Asp.NetCoreBestPractices.Web.ApiService;
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
    public class CategoriesController : Controller
    {
        private readonly CategoryApiService _categoryApiService;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService,IMapper mapper,CategoryApiService categoryApiService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
            _categoryApiService = categoryApiService;
        }


        public async Task<IActionResult> Index()
        {
            var categories = await _categoryApiService.GetAllAsync();
            return View(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            await _categoryApiService.AddAsync(categoryDto);
            return RedirectToAction("Index");
                
        }

        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryApiService.GetByIdAsync(id);
            return View (_mapper.Map<CategoryDto>(category));
        
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            
        await _categoryApiService.Update(categoryDto);
            return RedirectToAction("Index");
        
        }
        [ServiceFilter(typeof(CategoryNotFoundFilter))]
        public IActionResult Delete(int id)
        {
           var deleteCategory =  _categoryService.GetByIdAsync(id).Result;
            _categoryService.Remove(deleteCategory);
            return RedirectToAction("Index");
        }
    }
}
