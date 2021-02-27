using IMDBApp.Models.Classes;
using IMDBApp.Models.Request;
using IMDBApp.Models.Response;
using System.Collections.Generic;

namespace IMDBAppAPI.Services
{
    public interface IGenreService
    {
        /// <summary> Add the genre to the repository</summary>
        /// <returns> Retun true if executed successfully </returns>
        int Add(GenreRequest genreRequest);

        /// <summary> Returns the list of genres </summary>
        /// <returns>Retun list of genres </returns>
        IEnumerable<GenreResponse> GetAll();

        /// <summary> To get a actor </summary>
        /// /// <returns> Retun a actor</returns>
        GenreResponse Get(int id);

        /// <summary> Update the genre in database </summary>
        void Update(int id, GenreRequest genreRequest);

        /// <summary> Delete the genre in database </summary>
        void Delete(int id);

        /// <summary> To get the list of genres by movieId</summary>
        /// <returns> Retuns the list of genres</returns>
        IEnumerable<GenreResponse> GetByMovieId(int movieId);
    }
}