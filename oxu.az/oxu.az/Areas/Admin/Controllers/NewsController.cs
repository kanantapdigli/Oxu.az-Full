using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using oxu.az.Abstractions;
using oxu.az.Contexts;
using oxu.az.Models;

namespace oxu.az.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]/[action]")]
    public class NewsController : Controller
    {
        private readonly INewsRepository _newsRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IWebHostEnvironment _webHost;

        public NewsController(INewsRepository newsRepository, ICategoryRepository categoryRepository, IWebHostEnvironment webHost)
        {
            _newsRepository = newsRepository;
            _categoryRepository = categoryRepository;
            _webHost = webHost;
        }

        // GET: News
        public IActionResult Index()
        {
            var news = _newsRepository.GetAllNews();
            return View(news);
        }


        // GET: News/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = _newsRepository.GetNews(id);

            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // GET: News/Create
        public IActionResult Create()
        {
            ViewBag.Categories = _categoryRepository.GetSelectItems();
            return View();
        }

        // POST: News/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Title,CategoryId,File,Content,CreationTime,isMain")] News news)
        {
            if (news.File != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(news.File.FileName) + "-" + DateTime.Now.ToString("MM-dd-yyyy") + Path.GetExtension(news.File.FileName);

                news.FileName = fileName;

                if (ModelState.IsValid)
                {
                    var rootPath = Path.Combine(_webHost.WebRootPath, "images", news.FileName);

                    using (FileStream fileStream = new FileStream(rootPath, FileMode.Create))
                    {
                        news.File.CopyTo(fileStream);
                    }

                    news.CreationTime = DateTime.Now;

                    _newsRepository.AddNews(news);
                    return RedirectToAction(nameof(Index));
                }

            }

            ViewBag.Categories = _categoryRepository.GetSelectItems();
            return View(news);
        }

        // GET: News/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = _newsRepository.GetNews(id);

            if (news == null)
            {
                return NotFound();
            }
            ViewBag.Categories = _categoryRepository.GetSelectItems();
            return View(news);
        }

        // POST: News/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, [Bind("Id,Title,CategoryId,File,FileName,Content,CreationTime,isMain")] News news)
        {
            if (id != news.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (news.File != null)
                {
                    var fileName = _newsRepository.GetNews(news.Id).FileName;

                    var rootPath = Path.Combine(_webHost.WebRootPath, "images", fileName);

                    System.IO.File.Delete(rootPath);

                    var _fileName = Path.GetFileNameWithoutExtension(news.File.FileName) + "-" + DateTime.Now.ToString("MM-dd-yyyy") + Path.GetExtension(news.File.FileName);

                    news.FileName = _fileName;

                    var _rootPath = Path.Combine(_webHost.WebRootPath, "images", news.FileName);

                    using (FileStream fileStream = new FileStream(_rootPath, FileMode.Create))
                    {
                        news.File.CopyTo(fileStream);
                    }
                }

                _newsRepository.EditNews(news);

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = _categoryRepository.GetSelectItems();
            return View(news);
        }

        // GET: News/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = _newsRepository.GetNews(id);

            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _newsRepository.DeleteNews(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
