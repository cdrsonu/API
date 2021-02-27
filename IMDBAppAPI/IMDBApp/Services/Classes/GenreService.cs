using IMDB.Repository.Interfaces;
using IMDBApp.Models.Classes;
using IMDBApp.Models.Request;
using IMDBApp.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IMDBAppAPI.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        /// <inheritdoc/>
        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        /// <inheritdoc/>
        public int Add(GenreRequest genre)
        {
            var newGenre = new Genre
            {
                Name = genre.Name
            };
            return _genreRepository.Add(newGenre);
        }

        /// <inheritdoc/>
        public void Delete(int id)
        {
            _genreRepository.Delete(id);
        }

        /// <inheritdoc/>
        public GenreResponse Get(int id)
        {

            var genre = _genreRepository.Get(id);
            return new GenreResponse
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }

        /// <inheritdoc/>
        public IEnumerable<GenreResponse> GetAll()
        {
            var genres = _genreRepository.GetAll();
            var genersResponse = new List<GenreResponse>();
            foreach (var actor in genres)
            {
                genersResponse.Add(new GenreResponse
                {
                    Id = actor.Id,
                    Name = actor.Name
                });
            }
            return genersResponse;
        }

        public IEnumerable<GenreResponse> GetByMovieId(int movieId)
        {
            return _genreRepository.GetByMovieId(movieId).Select(genre => new GenreResponse
            {
                Id = genre.Id,
                Name = genre.Name
            });
        }

        /// <inheritdoc/>
        public void Update(int id, GenreRequest genreRequest)
        {
            var genre = new Genre
            {
                Id = id,
                Name = genreRequest.Name
            };
            _genreRepository.Update(id, genre);
        }

    }
}
