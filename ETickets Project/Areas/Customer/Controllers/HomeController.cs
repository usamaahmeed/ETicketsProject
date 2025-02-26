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
        private readonly ICinemaMovieRepository cinemaMovieRepository;


        public HomeController(IMovieRepository movieRepository , IActorMoviesRepository actorMoviesRepository, ICinemaMovieRepository cinemaMovieRepository)
        {
            this.movieRepository = movieRepository;
            this.actorMoviesRepository = actorMoviesRepository;
            this.cinemaMovieRepository = cinemaMovieRepository;
        }

        public IActionResult Index()
        {
            var movies = movieRepository.Get(
                includes: new Expression<Func<Movie, object>>[]
                {
                    e => e.CinemaMovies,
                    e => e.Category
                }

            );

            var cinemaMovies = cinemaMovieRepository.Get(
                filter: e => e.MovieID == e.Movie.MovieID,
                includes: new Expression<Func<CinemaMovie, object>>[]
                {
                    e => e.Cinema
                }
            );

            ViewBag.CinemaMovies = cinemaMovies.ToList();

            return View(movies.ToList());
        }

        public IActionResult Details(int movieId)
        {
            var movie = movieRepository.GetOne
                (
                filter: e => e.MovieID == movieId,
                 includes:
                 [
                     e => e.CinemaMovies,
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

            var cinemaMovies = cinemaMovieRepository.Get(
                filter: e => e.MovieID == movieId,
                includes: new Expression<Func<CinemaMovie, object>>[]
                {
                    e => e.Cinema
                }
            );

            ViewBag.Actors = movieWithActors;
            ViewBag.CinemaMovies = cinemaMovies;


            return View(movie);
        }
        public IActionResult Privacy()
        {
            return View();
        }
    
    }
}
