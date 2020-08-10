using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using oxu.az.Abstractions;
using oxu.az.Contexts;
using oxu.az.Models;

namespace oxu.az.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INewsRepository _newsRepository;
        private readonly ICategoryRepository _categoryRepository;

        public HomeController(ILogger<HomeController> logger, INewsRepository newsRepository, ICategoryRepository categoryRepository)
        {
            _logger = logger;
            _newsRepository = newsRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var featuredNews = _newsRepository.GetFeaturedNews();
            var generalNews = _newsRepository.GetAllNews();

            HomeIndexViewModel model = new HomeIndexViewModel()
            {
                FeaturedNews = featuredNews,
                GeneralNews = generalNews
            };

            return View(model);
        }

        public IActionResult Policy()
        {
            var policyNews = _newsRepository.GetCategoryNews("Siyasət");
            return View(policyNews);
        }

        public IActionResult Economy()
        {
            var economyNews = _newsRepository.GetCategoryNews("İqtisadiyyat");
            return View(economyNews);
        }

        public IActionResult Society()
        {
            var societyNews = _newsRepository.GetCategoryNews("Cəmiyyət");
            return View(societyNews);
        }

        public IActionResult ShowBusiness()
        {
            var showNews = _newsRepository.GetCategoryNews("Şou-Biznes");
            return View(showNews);
        }

        public IActionResult War()
        {
            var warNews = _newsRepository.GetCategoryNews("Müharibə");
            return View(warNews);
        }

        public IActionResult Sport()
        {
            var sportNews = _newsRepository.GetCategoryNews("İdman");
            return View(sportNews);
        }

        public IActionResult Criminal()
        {
            var criminalNews = _newsRepository.GetCategoryNews("Kriminal");
            return View(criminalNews);
        }

        public IActionResult Culture()
        {
            var cultureNews = _newsRepository.GetCategoryNews("Mədəniyyət");
            return View(cultureNews);
        }

        public IActionResult World()
        {
            var worldNews = _newsRepository.GetCategoryNews("Dünya");
            return View(worldNews);
        }

        public IActionResult Avto()
        {
            var avtoNews = _newsRepository.GetCategoryNews("Avto-Moto");
            return View(avtoNews);
        }

        public IActionResult IKT()
        {
            var IKTNews = _newsRepository.GetCategoryNews("İKT");
            return View(IKTNews);
        }

        public IActionResult Tourism()
        {
            var tourismNews = _newsRepository.GetCategoryNews("Turizm");
            return View(tourismNews);
        }

        public IActionResult Interesting()
        {
            var interestingNews = _newsRepository.GetCategoryNews("Maraqlı");
            return View(interestingNews);
        }

        public IActionResult Interview()
        {
            var interviewNews = _newsRepository.GetCategoryNews("Müsahibə");
            return View(interviewNews);
        }

        public IActionResult BakuTV()
        {
            var BAKUTVNews = _newsRepository.GetCategoryNews("Baku TV");
            return View(BAKUTVNews);
        }

        public IActionResult CinemaPlus()
        {
            var CinemaPlusNews = _newsRepository.GetCategoryNews("Cinema Plus");
            return View(CinemaPlusNews);
        }

        public IActionResult AllNews()
        {
            var AllNews = _newsRepository.GetAllNews();
            return View(AllNews);
        }

        public IActionResult News(int Id)
        {
            var chosenNews = _newsRepository.GetNews(Id);

            return View(chosenNews);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
