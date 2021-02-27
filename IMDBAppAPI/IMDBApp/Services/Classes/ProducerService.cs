using IMDB.Repository.Interfaces;
using IMDBApp.Models.Classes;
using IMDBApp.Models.Request;
using IMDBApp.Models.Response;
using System.Collections.Generic;
using System.Linq;

namespace IMDBAppAPI.Services
{
    public class ProducerService : IProducerService
    {
        private readonly IProducerRepository _producerRepository;

        /// <inheritdoc/>
        public ProducerService(IProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }

        /// <inheritdoc/>
        public int Add(ProducerRequest producerRequest)
        {
            var producer = new Producer
            {
                Name = producerRequest.Name,
                Dob = producerRequest.Dob,
                Gender = producerRequest.Gender,
                Bio = producerRequest.Bio
            };
            return _producerRepository.Add(producer);
        }

        /// <inheritdoc/>
        public void Delete(int id)
        {
            _producerRepository.Delete(id);
        }

        /// <inheritdoc/>
        public ProducerResponse Get(int id)
        {

            var producer = _producerRepository.Get(id);
            return new ProducerResponse
            {
                Id = producer.Id,
                Name = producer.Name,
                Gender = producer.Gender,
                Dob = producer.Dob,
                Bio = producer.Bio
            };
        }

        /// <inheritdoc/>
        public IEnumerable<ProducerResponse> GetAll()
        {
            return _producerRepository.GetAll().Select(producer => new ProducerResponse
            {
                Id = producer.Id,
                Name = producer.Name,
                Gender = producer.Gender,
                Dob = producer.Dob,
                Bio = producer.Bio
            });
        }

        /// <inheritdoc/>
        public ProducerResponse GetByMovieId(int movieId)
        {
            var producer = _producerRepository.GetByMovieId(movieId);
            return new ProducerResponse
            {
                Id = producer.Id,
                Name = producer.Name,
                Gender = producer.Gender,
                Dob = producer.Dob,
                Bio = producer.Bio
            };
        }

        /// <inheritdoc/>
        public void Update(int id, ProducerRequest producerRequest)
        {
            var producer = new Producer
            {
                Id = id,
                Name = producerRequest.Name,
                Gender = producerRequest.Gender,
                Dob = producerRequest.Dob,
                Bio = producerRequest.Bio
            };
           _producerRepository.Update(id, producer);
        }
    }
}