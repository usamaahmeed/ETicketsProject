using System.Diagnostics;
using System.Linq.Expressions;
using ETickets_Project.Models;
using ETickets_Project.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace ETickets_Project.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IMovieRepository movieRepository;
        private readonly IActorMoviesRepository actorMoviesRepository;


        public HomeController(IMovieRepository movieRepository , IActorMoviesRepository actorMoviesRepository)
        {
            this.movieRepository = movieRepository;
            this.actorMoviesRepository = actorMoviesRepository;
        }

        public IActionResult Index()
        {
            var movies = movieRepository.Get(
                filter: e => e.CategoryId == e.Category.CategoryID && e.CinemaId == e.Cinema.CinemaID, // Filtering condition
                includes: new Expression<Func<Movie, object>>[]
                {
                    e => e.Cinema,
                    e => e.Category
                }
            );

            return View(movies.ToList());
        }

        public IActionResult Details(int movieId)
        {
            var movie = movieRepository.GetOne
                (
                filter: e => e.MovieID == movieId,
                 includes:
                 [
                     e => e.Cinema,
                     e => e.Category,
                      e => e.ActorMovies
                     ]
                );

            var movieWithActors = actorMoviesRepository.Get(
                filter: e => e.MovieID == movieId,
                includes: new Expression<Func<ActorMovie, object>>[]
                {
                    e => e.Actor
                }
            );
            ViewBag.Actors = movieWithActors;


            return View(movie);
        }
        public IActionResult Privacy()
        {
            return View();
        }
    
    }
}
