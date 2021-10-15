﻿using Dal.Contracts;
using Dal.Models;
using Ipl.Databases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ipl.Repositories
{
    class CategoryRepository : ICategoryRepository
    {
        private readonly ShopDbContext _shopDbContext;
        public CategoryRepository(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }

        public async Task<IEnumerable<Category>> AllAsync()
        {
            return await _shopDbContext.Categories.ToArrayAsync();
        }

        public void Create(Category category)
        {
            _shopDbContext.Add(category);
        }

        public Task<Category> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByIdAsyncWithRelationships(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Category category)
        {
            _shopDbContext.Remove(category);
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
