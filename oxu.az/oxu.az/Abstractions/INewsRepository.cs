using Microsoft.AspNetCore.Mvc.Rendering;
using oxu.az.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oxu.az.Abstractions
{
    public interface INewsRepository
    {
        News GetNews(int? Id);

        List<News> GetAllNews();

        List<News> GetCategoryNews(string CategoryName);

        void  AddNews(News news);

        void EditNews(News news);

        void EditNewsStat(News news);

        void DeleteNews(int? Id);


        List<News> GetFeaturedNews();

    }
}
