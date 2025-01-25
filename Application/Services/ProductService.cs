using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repository;
using Application.ViewModels;
using Database.Context;
using Database.Entities;

namespace Application.Services
{
    public class ProductService
    {
        //define the logic for the methods from Repository

        private readonly ProductRepository _repo;

        public ProductService(ApplicationContext _context)
        {
            _repo = new(_context);
        }

        public async Task Update(SaveProductViewModel model)
        {
            Product product = new();
            product.Id = model.Id;
            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.ImagePath = model.ImagePath;
            product.CategoryId = model.CategoryId;

            await _repo.updateAsync(product);
        }

        public async Task AddAsync(SaveProductViewModel model)
        {
            Product product = new();
            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.ImagePath = model.ImagePath;
            product.CategoryId = model.CategoryId;

            await _repo.AddAsync(product);
        }

        public async Task<SaveProductViewModel> GetByIdSaveViewModel(int id)
        {
            var product = await _repo.GetByIdAsync(id);
            SaveProductViewModel model = new();
            model.Id = product.Id;
            model.Name = product.Name;
            model.Description = product.Description;
            model.Price = product.Price;
            model.ImagePath = product.ImagePath;
            model.CategoryId = product.CategoryId;

            return model;
        }

        public async Task<List<ProductViewModel>> GetAllViewModel()
        {
            var productList = await _repo.GetAllAsync();
            return productList.Select(product => new ProductViewModel
            {
                Name = product.Name,
                Description = product.Description,
                Id = product.Id,
                Price = product.Price,
                ImagePath = product.ImagePath,
            }).ToList();
        }

        public async Task Delete(int id)
        {
            var product = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(product);
        }
    }
}
