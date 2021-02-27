using IMDB.Repository.Interfaces;
using IMDBApp.Models.Classes;
using IMDBApp.Models.Request;
using IMDBApp.Models.Response;
using System.Collections.Generic;
using System;
using System.Linq;

namespace IMDBAppAPI.Services
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;

        public ActorService(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        /// <inheritdoc/>
        public int Add(ActorRequest actorRequest)
        {
            var actor = new Actor
            {
                Name = actorRequest.Name,
                Dob = actorRequest.Dob,
                Gender = actorRequest.Gender,
                Bio = actorRequest.Bio
            };
            return _actorRepository.Add(actor);
        }

        /// <inheritdoc/>
        public void Delete(int id)
        {
             _actorRepository.Delete(id);
        }

        /// <inheritdoc/>
        public ActorResponse Get(int id)
        {
            var actor = _actorRepository.Get(id);
            return new ActorResponse
            {
                Id = actor.Id,
                Name = actor.Name,
                Gender = actor.Gender,
                Dob = actor.Dob,
                Bio = actor.Bio
            };
        }

        /// <inheritdoc/>
        public IEnumerable<ActorResponse> GetAll()
        {
            return _actorRepository.GetAll().Select(actor => new ActorResponse
            {

                Id = actor.Id,
                Name = actor.Name,
                Gender = actor.Gender,
                Dob = actor.Dob,
                Bio = actor.Bio
            });
        }

        public IEnumerable<ActorResponse> GetByMovieId(int movieId)
        {
            return _actorRepository.GetByMovieId(movieId).Select(actor => new ActorResponse
            {
                Id = actor.Id,
                Name = actor.Name,
                Bio = actor.Bio,
                Dob = actor.Dob,
                Gender = actor.Gender
            });
        }

        /// <inheritdoc/>
        public void Update(int id, ActorRequest actor)
        {
            _actorRepository.Update(id, new Actor
            {
                Id = id,
                Name = actor.Name,
                Gender = actor.Gender,
                Dob = actor.Dob,
                Bio = actor.Bio
            });
        }
    }
}