using IMDBApp.Models.Classes;
using System.Collections.Generic;

namespace IMDB.Repository.Interfaces
{
    public interface IGenreRepository
    {
        /// <summary> Add the genre to the repository</summary>
        /// <returns> Retun true if executed successfully </returns>
        int Add(Genre genre);

        /// <summary> Returns the list of genre </summary>
        /// <returns>Retun list of genre </returns>
        IEnumerable<Genre> GetAll();

        /// <summary> To get a genre </summary>
        /// /// <returns> Retun a genre</returns>
        Genre Get(int id);

        /// <summary> Update the genre in database </summary>
        void Update(int id, Genre genre);

        /// <summary> Delete the genre in database </summary>
        void Delete(int id);

        /// <summary> To get the list of genre agianst given movieId</summary>
        /// <returns> Retun the list of genres</returns>
        IEnumerable<Genre> GetByMovieId(int movieId);


    }
}
