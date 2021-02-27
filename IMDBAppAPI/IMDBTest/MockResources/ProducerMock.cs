using System;
using Moq;
using IMDB.Repository.Interfaces;
using System.Collections.Generic;
using IMDBApp.Models.Classes;
using System.Linq;

namespace IMDB.Test.MockResources
{
    public class ProducerMock
    {
        public static readonly Mock<IProducerRepository> ProducerRepoMock = new Mock<IProducerRepository>();

        private static IEnumerable<Producer> ListOfProducers()
        {
            return new List<Producer>
            {
                new Producer
                {
                    Id = 1,
                    Name = "Arjun",
                    Bio = "--",
                    Gender = "Male",
                    Dob = Convert.ToDateTime("1998-05-14")
                },
                 new Producer
                {
                    Id = 2,
                    Name = "Arun",
                    Bio = "--",
                    Gender = "Male",
                    Dob = Convert.ToDateTime("2004-09-11")
                }
            };
        }

        public static void MockGetByMovieId()
        {
            ProducerRepoMock.Setup(repo => repo.GetByMovieId(It.IsAny<int>())).Returns((int id) => ListOfProducers().Single(a => a.Id == id));

        }

        public static void MockGetAll()
        {
            ProducerRepoMock.Setup(repo => repo.GetAll()).Returns(ListOfProducers());
        }

        public static void MockGet()
        {
            ProducerRepoMock.Setup(repo => repo.Get(It.IsAny<int>())).Returns((int id) => ListOfProducers().Single(a => a.Id == id));
        }

        public static void MockAdd()
        {
            ProducerRepoMock.Setup(repo => repo.Add(It.IsAny<Producer>())).Returns(10);
        }

        public static void MockUpdate()
        {
            ProducerRepoMock.Setup(repo => repo.Update(It.IsAny<int>(), It.IsAny<Producer>()));
        }

        public static void MockDelete()
        {
            ProducerRepoMock.Setup(repo => repo.Delete(It.IsAny<int>()));
        }
    }
}
