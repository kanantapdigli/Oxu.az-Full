using Microsoft.AspNetCore.Mvc.Rendering;
using oxu.az.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oxu.az.Abstractions
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories();

        List<SelectListItem> GetSelectItems();

    }
}
