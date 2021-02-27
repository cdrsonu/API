using IMDBApp.Models.Request;
using IMDBApp.Models.Response;
using System.Collections.Generic;

namespace IMDBAppAPI.Services
{
    public interface IMovieService
    {
        /// <summary> Add the movie to the repository</summary>
        /// <returns> Retun true if executed successfully </returns>
        int Add(MovieRequest movieRequest);

        /// <summary> Returns the list of movies </summary>
        /// <returns>Retun list of movies </returns>
        IEnumerable<MovieResponse> GetAll();

        /// <summary> To get a movie </summary>
        /// /// <returns> Retun a movie</returns>
        MovieResponse Get(int id);

        /// <summary> Update the movie in database </summary>
        void Update(int id, MovieRequest movieRequest);

        /// <summary> Delete the movie in database </summary>
        void Delete(int id);
    }
}
