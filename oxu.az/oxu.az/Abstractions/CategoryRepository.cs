using Microsoft.AspNetCore.Mvc.Rendering;
using oxu.az.Abstractions;
using oxu.az.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oxu.az.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly NewsContext _context;

        public CategoryRepository(NewsContext context)
        {
            _context = context;
        }

        public List<Category> GetAllCategories()
        {
            var categories = _context.Categories.ToList();
            return categories;
        }

        public List<SelectListItem> GetSelectItems()
        {
            var items = _context.Categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name

            }).ToList();

            return items;
        }

    }
}
