using ETickets_Project.Data;
using ETickets_Project.Models;
using ETickets_Project.Repositories;
using ETickets_Project.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace ETickets_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CinemaController : Controller
    {
        
       private readonly ICinemaRepository cinemaRepository;
       private readonly IMovieRepository movieRepository;

        public CinemaController(ICinemaRepository cinemaRepository, IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
            this.cinemaRepository = cinemaRepository;
        }

        public IActionResult Index()
        {
            var cinemas = cinemaRepository.Get();

            return View(cinemas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cinema cinema)
        {
            //ModelState.Remove("Products");

            if (ModelState.IsValid)
            {
                cinemaRepository.Create(cinema);
                cinemaRepository.Commit();

                TempData["notifation"] = "Add company successfuly";

                return RedirectToAction(nameof(Index));
            }

            return View(cinema);
        }

        [HttpGet]
        public IActionResult Edit(int cinemaId)
        {
            var cinema = cinemaRepository.GetOne(e => e.CinemaID == cinemaId);
            if (cinema != null)
            {
                return View(cinema);
            }

            return RedirectToAction("NotFoundPage", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cinema cinema)
        {
            if (cinema != null)
            {
    
                cinemaRepository.Edit(cinema);
                cinemaRepository.Commit();

                TempData["notifation"] = "Update company successfuly";

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("NotFoundPage", "Home");
        }
    }
}
