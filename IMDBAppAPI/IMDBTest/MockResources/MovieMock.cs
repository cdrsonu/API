using IMDB.Repository.Interfaces;
using IMDBApp.Models.Classes;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IMDB.Test.MockResources
{
    public class MovieMock
    {
        public static readonly Mock<IActorRepository> ActorRepoMock = new Mock<IActorRepository>();
        public static readonly Mock<IProducerRepository> ProducerRepoMock = new Mock<IProducerRepository>();
        public static readonly Mock<IGenreRepository> GenreRepoMock = new Mock<IGenreRepository>();
        public static readonly Mock<IMovieRepository> MovieRepoMock = new Mock<IMovieRepository>();

        private static IEnumerable<Movie> ListOfMovies()
        {
            return new List<Movie>
            {
                new Movie
                {
                   Id=1,
                   Name = "Rocky",
                   YearOfRelease = 2010,
                   Plot="--",
                   ProducerId = 1,
                   CoverImage = null
                }
            };
        }

        public static void MockGetAll()
        {
            MovieRepoMock.Setup(repo => repo.GetAll()).Returns(ListOfMovies());
        }

        public static void MockGet()
        {
            MovieRepoMock.Setup(repo => repo.Get(It.IsAny<int>())).Returns((int id) => ListOfMovies().Single(a => a.Id == id));
        }

        public static void MockAdd()
        { 
            MovieRepoMock.Setup(repo => repo.Add(It.IsAny<Movie>(), It.IsAny<List<int>>(), It.IsAny<List<int>>())).Returns(10);
        }

        public static void MockUpdate()
        {
            ActorRepoMock.Setup(repo => repo.Update(It.IsAny<int>(), It.IsAny<Actor>()));
        }

        public static void MockDelete()
        {
            ActorRepoMock.Setup(repo => repo.Delete(It.IsAny<int>()));
        }
    }
}
