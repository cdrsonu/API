using IMDBApp.Models.Classes;
using System.Collections.Generic;

namespace IMDB.Repository.Interfaces
{
    public interface IMovieRepository
    {
        /// <summary> Add the movie to the database</summary>
        /// <returns> Retun the id of the movie </returns>
        int Add(Movie movie, List<int> actorIds, List<int> genreIds);

        /// <summary> Returns the list of movies </summary>
        /// <returns>Retun list of movies </returns>
        IEnumerable<Movie> GetAll();

        /// <summary> To get a movie </summary>
        /// /// <returns> Retun a movie</returns>
        Movie Get(int id);

        /// <summary> To update the movie in database along with it's mapping table </summary>
        void Update(int id, Movie movie, List<int> actorIds, List<int> genreIds);

        /// <summary> Delete the movie in database </summary>
        void Delete(int id);
    }
}
