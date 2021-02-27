using IMDBApp.Models.Classes;
using IMDBApp.Models.Request;
using IMDBApp.Models.Response;
using System.Collections.Generic;

namespace IMDBAppAPI.Services
{
    public interface IActorService
    {
        /// <summary> Add the actor to the repository</summary>
        /// <returns> Retun true if executed successfully </returns>
        int Add(ActorRequest actorRequest);

        /// <summary> Returns the list of actors </summary>
        /// <returns>Retun list of actors </returns>
        IEnumerable<ActorResponse> GetAll();

        /// <summary> To get a actor </summary>
        /// /// <returns> Retun a actor</returns>
        ActorResponse Get(int id);

        /// <summary> Update the actor in database </summary>
        void Update(int id, ActorRequest actorRequest);

        /// <summary> Delete the actor in database </summary>
        void Delete(int id);

        /// <summary> To get the list of actors by movieId</summary>
        /// <returns> Retuns the list of actors</returns>
        IEnumerable<ActorResponse> GetByMovieId(int movieId);
    }
}