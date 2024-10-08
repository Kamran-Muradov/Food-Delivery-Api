﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Category>> GetPaginateDatasAsync(int page, int take, string? searchText)
        {
            var query = Entities.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                query = query.Where(m => m.Name.Contains(searchText));
            }

            return await query
                .OrderByDescending(m => m.Id)
                .Skip((page - 1) * take)
                .Take(take)
                .Include(m => m.CategoryImage)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetAllWithImageAsync()
        {
            return await Entities
                .Include(m => m.CategoryImage)
                .Include(m => m.Menus)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Category> GetByIdWithImageAsync(int id)
        {
            return await Entities
                .Where(m => m.Id == id)
                .Include(m => m.CategoryImage)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<Category> GetByNameAsync(string name)
        {
            return await Entities.AsNoTracking().FirstOrDefaultAsync(m => m.Name == name);
        }

        public async Task<bool> ExistAsync(string name, int? excludeId = null)
        {
            return await Entities
                .Where(m => m.Id != excludeId)
                .AnyAsync(m => m.Name == name);
        }
    }
}
