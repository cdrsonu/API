using Dapper;
using IMDB.Repository.Interfaces;
using IMDBApp.Models.Classes;
using IMDBAppAPI;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace IMDBApp.Repository.Classes
{
    public class ActorRepository : IActorRepository
    {
        private readonly ConnectionString _connectionString;

        public ActorRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString.Value;
        }

        /// <inheritdoc/>
        public int Add(Actor actor)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString.IMDBDb))
            {
                const string sql = @"
                                    INSERT INTO [dbo].[Actors] (
                                        Name
                                        ,Bio
                                        ,Gender
                                        ,Dob
                                        ,CreateAt
                                        )
                                    OUTPUT INSERTED.Id
                                    VALUES (
                                        @Name
                                        ,@Bio
                                        ,@Gender
                                        ,@Dob
                                        ,GETDATE()
                                        )";
                return connection.QuerySingle<int>(sql, new
                {
                    actor.Name,
                    actor.Bio,
                    actor.Gender,
                    actor.Dob
                });
            }
        }


        /// <inheritdoc/>
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString.IMDBDb))
            {
                const string sql = @"
                        DELETE
                        FROM [dbo].[Actors]
                        WHERE Id = @Id";
                connection.Execute(sql, new { id });
            }
        }


        /// <inheritdoc/>
        public Actor Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString.IMDBDb))
            {
                const string sql = @"
                        SELECT Id [Id]
                            ,Name [Name]
                            ,Bio [Bio]
                            ,Gender [Gender]
                            ,Dob [Dob]
                        FROM [dbo].[Actors]
                        WHERE Id = @Id";
                return connection.QuerySingle<Actor>(sql, new { id });
            }
        }

        /// <inheritdoc/>
        public IEnumerable<Actor> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString.IMDBDb))
            {

                const string sql = @"
                        SELECT Id [Id]
                            ,Name [Name]
                            ,Bio [Bio]
                            ,Gender [Gender]
                            ,Dob [Dob]
                        FROM [dbo].[Actors]";
                return connection.Query<Actor>(sql);
            }
        }

        /// <inheritdoc/>
        public void Update(int id, Actor actor)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString.IMDBDb))
            {
                const string sql = @"
                        UPDATE [dbo].[Actors]
                        SET Name = @Name
                            ,Bio = @Bio
                            ,Gender = @Gender
                            ,Dob = @Dob
                            ,UpdatedAt = GETDATE()
                        WHERE Id = @Id";
                connection.Execute(sql, new
                {
                    actor.Name,
                    actor.Bio,
                    actor.Gender,
                    actor.Dob,
                    id
                });
            }
        }

        public IEnumerable<Actor> GetByMovieId(int movieId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString.IMDBDb))
            {
                const string sql = @"
                                SELECT Id [Id]
                                    ,Name [Name]
                                    ,Bio [Bio]
                                    ,Gender [Gender]
                                    ,Dob [Dob]
                                FROM [dbo].[Actors] A
                                INNER JOIN [dbo].[ActorMovies] AM ON A.Id = AM.ActorId
                                WHERE AM.MovieId = @MovieId";
                return connection.Query<Actor>(sql, new { movieId });
            }
        }
    }
}
