using System;
using Moq;
using IMDB.Repository.Interfaces;
using System.Collections.Generic;
using IMDBApp.Models.Classes;
using System.Linq;

namespace SessionDemo.Test.MockResources
{

    public class ActorMock
    {
        public static readonly Mock<IActorRepository> ActorRepoMock = new Mock<IActorRepository>();
        private static IEnumerable<Actor> ListOfActors()
        {
            return new List<Actor>
            {
                new Actor
                {
                    Id = 1,
                    Name = "Mila Kunis",
                    Bio = "--",
                    Gender = "Female",
                    Dob = Convert.ToDateTime("1986-11-14")
                },
                 new Actor
                {
                    Id = 2,
                    Name = "George Michael",
                    Bio = "--",
                    Gender = "Male",
                    Dob = Convert.ToDateTime("1978-11-23")
                }
            };
        }
        private static Dictionary<int, List<int>> Movie_Actors_Mapping()
        {
            var marpper = new Dictionary<int, List<int>>
            {
                { 1, new List<int> { 1, 2 } },
                { 2, new List<int> { 2, 3 } }
            };
            return marpper;
        }

        public static void MockGetByMovieId()
        {
            ActorRepoMock.Setup(repo => repo.GetByMovieId(It.IsAny<int>())).Returns((int id) => ListOfActors().Where(a => Movie_Actors_Mapping()[id].Contains(a.Id)));

        }

        public static void MockGetAll()
        {
            ActorRepoMock.Setup(repo => repo.GetAll()).Returns(ListOfActors());
        }

        public static void MockGet()
        {
            ActorRepoMock.Setup(repo => repo.Get(It.IsAny<int>())).Returns((int id) => ListOfActors().Single(a => a.Id == id));
        }

        public static void MockAdd()
        {
            ActorRepoMock.Setup(repo => repo.Add(It.IsAny<Actor>())).Returns(10);
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