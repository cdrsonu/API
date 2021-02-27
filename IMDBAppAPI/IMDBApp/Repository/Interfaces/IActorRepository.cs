using IMDBApp.Models.Classes;
using System.Collections.Generic;

namespace IMDB.Repository.Interfaces
{
    public interface IActorRepository
    {

        /// <summary> Add the actor to the repository</summary>
        /// <returns> Retun the id executed successfully </returns>
        int Add(Actor actor);

        /// <summary> To get list of actors </summary>
        /// <returns>Retun list of actors </returns>
        IEnumerable<Actor> GetAll();

        /// <summary> To get a actor </summary>
        /// /// <returns> Retun a actor</returns>
        Actor Get(int id);

        /// <summary> Update the actor in database </summary>
        void Update(int id, Actor actor);

        /// <summary> Delete the actor in database </summary>
        void Delete(int id);

        /// <summary> To get the list of actor agianst given movieId</summary>
        /// <returns> Retun the list of actors</returns>
        IEnumerable<Actor> GetByMovieId(int movieId);
    }
}
