using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using oxu.az.Abstractions;

namespace oxu.az.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsRepository _newsRepository;

        public NewsController(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
          
        }

        public ContentResult Like(int NewsId)
        {
            var likedNews = _newsRepository.GetNews(NewsId);

            likedNews.Like++;

            _newsRepository.EditNewsStat(likedNews);

            return Content(likedNews.Like.ToString());
        }

        public ContentResult Unlike(int NewsId)
        {
            var unlikedNews = _newsRepository.GetNews(NewsId);

            unlikedNews.Unlike++;

            _newsRepository.EditNewsStat(unlikedNews);

            return Content(unlikedNews.Unlike.ToString());
        }

        public ContentResult View(int NewsId)
        {
            var viewedNews = _newsRepository.GetNews(NewsId);

            viewedNews.View++;

            _newsRepository.EditNewsStat(viewedNews);

            return Content(viewedNews.View.ToString());
        }
    }
}
