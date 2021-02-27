using IMDBApp.Models.Classes;
using IMDBApp.Models.Request;
using IMDBApp.Models.Response;
using System.Collections.Generic;

namespace IMDBAppAPI.Services
{
    public interface IProducerService
    {
        /// <summary> Add the producer to the repository</summary>
        /// <returns> Retun true if executed successfully </returns>
        int Add(ProducerRequest producerRequest);

        /// <summary> Returns the list of producer </summary>
        /// <returns>Retun list of producers </returns>
        IEnumerable<ProducerResponse> GetAll();

        /// <summary> To get a producer </summary>
        /// /// <returns> Retun a producer</returns>
        ProducerResponse Get(int id);

        /// <summary> Update the producer in database </summary>
        void Update(int id, ProducerRequest producerRequest);

        /// <summary> Delete the producer in database </summary>
        void Delete(int id);

        /// <summary> To get the Producer by movieId</summary>
        /// <returns> Retuns the Producer</returns>
        ProducerResponse GetByMovieId(int movieId);
    }

}