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
    public class CategoriesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService,IMapper mapper)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }


        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
            return RedirectToAction("Index");
                
        }

        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            return View (_mapper.Map<CategoryDto>(category));
        
        }
        [HttpPost]
        public IActionResult Update(CategoryDto categoryDto)
        {
            var newCategory = _mapper.Map<Category>(categoryDto);
            _categoryService.Update(newCategory);
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
