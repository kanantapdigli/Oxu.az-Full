using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using oxu.az.Abstractions;
using oxu.az.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oxu.az.Models
{
    public class NewsRepository : INewsRepository
    {
        private readonly NewsContext _context;

        public NewsRepository(NewsContext context)
        {
            _context = context;
        }

        public void AddNews(News news)
        {
            _context.News.Add(news);
            _context.SaveChanges();
        }

        public void DeleteNews(int? id)
        {
            var news = _context.News.Find(id);
            _context.News.Remove(news);
            _context.SaveChanges();
        }

        public void EditNewsStat(News news)
        {
            UpdateDb(news);
        }

        public void EditNews(News news)
        {
            var activeNews = _context.News.Find(news.Id);

            news.Like = activeNews.Like;
            news.Unlike = activeNews.Unlike;
            news.View = activeNews.View;

            UpdateDb(news);
        }

     

        public List<News> GetAllNews()
        {
            var news = _context.News.Include("Category").OrderByDescending(n => n.CreationTime).ToList();

            return news;
        }

        public List<News> GetCategoryNews(string CategoryName)
        {
            var news = _context.News.Include("Category").Where(n => n.Category.Name == CategoryName).OrderByDescending(n => n.CreationTime).ToList();
            return news;
        }

        public List<News> GetFeaturedNews()
        {
            var featuredNews = _context.News.Where(n => n.isMain == true).OrderByDescending(n => n.CreationTime).Take(5).ToList();
            return featuredNews;
        }

        public News GetNews(int? Id)
        {
            var news = _context.News.Include("Category").FirstOrDefault(n => n.Id == Id);
            return news;
        }

        public void UpdateDb(News news)
        {
            _context.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);
            _context.Entry(news).State = EntityState.Modified;

            _context.SaveChanges();
        }
    }
}
