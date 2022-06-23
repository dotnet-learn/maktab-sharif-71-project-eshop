﻿using Microsoft.AspNetCore.Mvc;
using App.Infrastructures.Database.SqlServer.Data;



using Microsoft.AspNetCore.Mvc.Rendering;
using App.EndPoints.Mvc.AdminUI.ViewModels;
using App.Domain.Core.Product.Entities;
using App.Domain.Core.BaseData.Contarcts.Repositories;
using App.Domain.Core.Product.Contarcts.Repositories;
using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Contacts.AppServices;
using App.Domain.Core.BaseData.Contarcts.AppServices;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{

    public class ProductController : Controller
    {
        private readonly IProductAppService _productAppService;
        private readonly IBrandAppService _brandAppService;
        //private readonly IProductQueryRepository _productQueryRepository;
        //private readonly IProductCommandRepository _productCommandRepository;
        private readonly AppDbContext _dbContext;

        //public ProductController(IProductQueryRepository productQueryRepository, IProductCommandRepository productCommandRepository, AppDbContext dbContext)
        public ProductController(IProductAppService productAppService, IProductQueryRepository productQueryRepository, IBrandAppService brandAppService)
        {
            _productAppService = productAppService;
            _brandAppService = brandAppService;
            //_dbContext = dbContext;
            //_productQueryRepository = productQueryRepository;
        }
        public async Task<IActionResult> Index()
        {
            var products =await _productAppService.GetAll();
            //var products =await _productQueryRepository.GetAll();
            return View(products);
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Brands = _productAppService.GetAllBrands()
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });
            ViewBag.Colors = _productAppService.GetAllColors()
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });

            ViewBag.Categories = _productAppService.GetAllCategories()
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });
            ViewBag.Models = _productAppService.GetAllModels()
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });

            List<SelectListItem> boolSelectListItem = new List<SelectListItem>();
            boolSelectListItem.Add(new SelectListItem()
            {
                Text="Yes",
                Value=true.ToString()
            });
            boolSelectListItem.Add(new SelectListItem()
            {
                Text = "No",
                Value = false.ToString()
            }); 
            ViewBag.IsOrginal = boolSelectListItem;
            ViewBag.IsShowPrice = boolSelectListItem;
            ViewBag.IsActive = boolSelectListItem;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO model)
        {
            /*model.IsDeleted = false;
            Product pr = new Product()
            {
                BrandId = model.BrandId,
                CategoryId = model.CategoryId,
                OperatorId = 1,
                ModelId = model.ModelId,
                Count = model.Count,
                Weight = model.Weight,
                CreationDate = DateTime.Now,
                Description = model.Description,
                IsActive = model.IsActive,
                IsDeleted = model.IsDeleted,
                IsOrginal = model.IsOrginal,
                Name=model.Name,
                IsShowPrice = model.IsShowPrice,
                Price=model.Price,
            };*/
            await _productAppService.AddProduct(model);
            /*_dbContext.Products.Add(pr);
            _dbContext.SaveChanges();*/
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            //var model = _dbContext.Products.SingleOrDefault(x => x.Id == id);
            var model =await _productAppService.Get(id);
            model.OperatorId = 1;

            ViewBag.Brands = _productAppService.GetAllBrands()
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });
            ViewBag.Colors = _productAppService.GetAllColors()
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });

            ViewBag.Categories = _productAppService.GetAllCategories()
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });
            ViewBag.Models = _productAppService.GetAllModels()
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });


            List<SelectListItem> boolSelectListItem = new List<SelectListItem>();
            boolSelectListItem.Add(new SelectListItem()
            {
                Text = "Yes",
                Value = true.ToString()
            });
            boolSelectListItem.Add(new SelectListItem()
            {
                Text = "No",
                Value = false.ToString()
            });
            ViewBag.IsOrginal = boolSelectListItem;
            ViewBag.IsShowPrice = boolSelectListItem;
            ViewBag.IsActive = boolSelectListItem;
            /*ProductDTO productDTO = new ProductDTO() {
                BrandId = model.BrandId,
                CategoryId = model.CategoryId,
                OperatorId = 1,
                ModelId = model.ModelId,
                Count = model.Count,
                Weight = model.Weight,
                CreationDate = DateTime.Now,
                Description = model.Description,
                IsActive = model.IsActive,
                IsDeleted = model.IsDeleted,
                IsOrginal = model.IsOrginal,
                Name = model.Name,
                IsShowPrice = model.IsShowPrice,
                Price = model.Price,
            };

*/
            return View(model);
            
        }
        [HttpPost]
        public IActionResult Update(ProductDTO model)
        {
            /*Product pr = new Product()
            {
                Id=model.Id,
                BrandId = model.BrandId,
                CategoryId = model.CategoryId,
                OperatorId = 1,
                ModelId = model.ModelId,
                Count = model.Count,
                Weight = model.Weight,
                CreationDate = DateTime.Now,
                Description = model.Description,
                IsActive = model.IsActive,
                IsDeleted = model.IsDeleted,
                IsOrginal = model.IsOrginal,
                Name = model.Name,
                IsShowPrice = model.IsShowPrice,
                Price = model.Price,


            };
            _dbContext.Products.Update(pr);
            _dbContext.SaveChanges();*/
            _productAppService.UpdateProduct(model);
            return RedirectToAction("Index");
        }
   
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _productAppService.Get(id);
            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> DeletePost(ProductDTO model)
        {
            /*Product pr = new Product()
            {
                Id = model.Id
            };*/
            await _productAppService.DeleteProduct(model);

            return RedirectToAction("Index");
        }

    }
}
