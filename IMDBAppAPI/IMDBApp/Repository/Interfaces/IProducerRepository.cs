using IMDBApp.Models.Classes;
using IMDBApp.Models.Response;
using System.Collections.Generic;

namespace IMDB.Repository.Interfaces
{
    public interface IProducerRepository
    {
        /// <summary> Add the Producer to the database</summary>
        /// <returns> Retun true if executed successfully </returns>
        int Add(Producer producer);

        /// <summary> Returns the list of Producer </summary>
        /// <returns>Retun list of Producer </returns>
        IEnumerable<Producer> GetAll();

        /// <summary> To get a Producer </summary>
        /// /// <returns> Retun Producer</returns>
        Producer Get(int id);

        /// <summary> Update the Producer in database </summary>
        void Update(int id, Producer producer);

        /// <summary> Delete the Producer in database </summary>
        void Delete(int id);

        /// <summary> Returns the list of Producer with given MovieId </summary>
        /// <returns>Retun list of Producer </returns>
        Producer GetByMovieId(int movieId);
    }
}
