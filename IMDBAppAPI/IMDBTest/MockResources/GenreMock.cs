using Moq;
using IMDB.Repository.Interfaces;
using System.Collections.Generic;
using IMDBApp.Models.Classes;
using System.Linq;

namespace IMDB.Test.MockResources
{
    public class GenreMock
    {
        public static readonly Mock<IGenreRepository> GenreRepoMock = new Mock<IGenreRepository>();

        private static IEnumerable<Genre> ListOfGenres()
        {
            return new List<Genre>
            {
                new Genre
                {
                    Id = 1,
                    Name = "Action"
                },
                new Genre
                {
                    Id = 2,
                    Name = "Thrill"
                },
                new Genre
                {
                     Id = 3,
                     Name= "Drama"
                }
            };
        }
        private static Dictionary<int, List<int>> Movie_Genre_Mapping()
        {
            var marpper = new Dictionary<int, List<int>>
            {
                { 1, new List<int> { 1, 3 } },
                { 2, new List<int> { 2, 3 } }
            };
            return marpper;
        }

        public static void MockGetByMovieId()
        {
            GenreRepoMock.Setup(repo => repo.GetByMovieId(It.IsAny<int>())).Returns((int id) => ListOfGenres().Where(a => Movie_Genre_Mapping()[id].Contains(a.Id)));

        }

        public static void MockGetAll()
        {
            GenreRepoMock.Setup(repo => repo.GetAll()).Returns(ListOfGenres());
        }

        public static void MockGet()
        {
            GenreRepoMock.Setup(repo => repo.Get(It.IsAny<int>())).Returns((int id) => ListOfGenres().Single(a => a.Id == id));
        }

        public static void MockAdd()
        {
            GenreRepoMock.Setup(repo => repo.Add(It.IsAny<Genre>())).Returns(10);
        }

        public static void MockUpdate()
        {
            GenreRepoMock.Setup(repo => repo.Update(It.IsAny<int>(), It.IsAny<Genre>()));
        }

        public static void MockDelete()
        {
            GenreRepoMock.Setup(repo => repo.Delete(It.IsAny<int>()));
        }
    }
}
