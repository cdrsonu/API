using IMDB.Repository.Interfaces;
using IMDBApp.Models.Classes;
using IMDBApp.Models.Request;
using IMDBApp.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IMDBAppAPI.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IActorService _actorService;
        private readonly IGenreService _genreService;
        private readonly IProducerService _producerService;


        public MovieService(IMovieRepository movieRepository, IActorService actorService, IGenreService genreService, IProducerService producerService)
        {
            _movieRepository = movieRepository;
            _actorService = actorService;
            _genreService = genreService;
            _producerService = producerService;
        }

        /// <inheritdoc/>
        public int Add(MovieRequest movieRequest)
        {
            var movie = new Movie()
            {
                Name = movieRequest.Name,
                Plot = movieRequest.Plot,
                YearOfRelease = movieRequest.YearOfRelease,
                ProducerId = movieRequest.ProducerId,
                CoverImage = movieRequest.CoverImage,
            };
            return _movieRepository.Add(movie, movieRequest.ActorIds, movieRequest.GenreIds);

        }

        /// <inheritdoc/>
        public void Delete(int id)
        {
            _movieRepository.Delete(id);
        }

        ///<inheritdoc/>
        public MovieResponse Get(int id)
        {
            var movie = _movieRepository.Get(id);
            return new MovieResponse
            {
                Id = movie.Id,
                Name = movie.Name,
                YearOfRelease = movie.YearOfRelease,
                Plot = movie.Plot,
                CoverImage = movie.CoverImage,
                Actors = _actorService.GetByMovieId(movie.Id).ToList(),
                Genres = _genreService.GetByMovieId(movie.Id).ToList(),
                Producer = movie.ProducerId == null ? null : _producerService.GetByMovieId(movie.Id)
            };
        }

        public IEnumerable<MovieResponse> GetAll()
        {
            return _movieRepository.GetAll().Select(movie => new MovieResponse
            {
                Id = movie.Id,
                Name = movie.Name,
                YearOfRelease = movie.YearOfRelease,
                Plot = movie.Plot,
                CoverImage = movie.CoverImage,
                Actors = _actorService.GetByMovieId(movie.Id).ToList(),
                Genres = _genreService.GetByMovieId(movie.Id).ToList(),
                Producer = movie.ProducerId == null ? null : _producerService.GetByMovieId(movie.Id)
            });
        }

        public void Update(int id, MovieRequest movieRequest)
        {
            var movie = new Movie
            {
                Id = id,
                Name = movieRequest.Name,
                YearOfRelease = movieRequest.YearOfRelease,
                Plot = movieRequest.Plot,
                CoverImage = movieRequest.CoverImage,
                ProducerId = movieRequest.ProducerId
            };
            _movieRepository.Update(id, movie, movieRequest.ActorIds, movieRequest.GenreIds);
        }
    }
}