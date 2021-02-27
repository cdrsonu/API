using Dapper;
using IMDB.Repository.Interfaces;
using IMDBApp.Models.Classes;
using IMDBAppAPI;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace IMDBApp.Repository.Classes
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ConnectionString _connectionString;

        public MovieRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString.Value;
        }

        /// <inheritdoc/>
        public int Add(Movie movie, List<int> actorIds, List<int> genreIds)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString.IMDBDb))
            {
                
                const string sql = @"usp_AddMovie";
                var values = new
                {
                    movie.Name,
                    movie.YearOfRelease,
                    movie.Plot,
                    movie.ProducerId,
                    movie.CoverImage,
                    ActorIds = string.Join(',', actorIds),
                    GenreIds = string.Join(',', genreIds)
                };
                return connection.QuerySingle<int>(sql, values, commandType: CommandType.StoredProcedure);
            }
        }


        /// <inheritdoc/>
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString.IMDBDb))
            {
                const string sql = @"
                                DELETE
                                FROM ActorMovies
                                WHERE MovieId = @MovieId

                                DELETE
                                FROM GenreMovies
                                WHERE MovieId = @MovieId

                                DELETE
                                FROM Movies
                                WHERE Id = @MovieId";

                connection.Execute(sql, new { MovieId = id });
            }
        }

        /// <inheritdoc/>
        public Movie Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString.IMDBDb))
            {
                const string sql = @"
                                 SELECT Id [Id]
                                    ,Name [name]
                                    ,YearOfRelease [YearOfRelease]
                                    ,Plot [Plot]
                                    ,ProducerId [ProducerId]
                                    ,CoverImage [CoverImage]
                                FROM [dbo].[Movies]
                                WHERE Id = @Id";
                return connection.QuerySingle<Movie>(sql, new { id });
            }
        }

        /// <inheritdoc/>
        public IEnumerable<Movie> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString.IMDBDb))
            {
                const string sql = @"
                                 SELECT Id [Id]
                                    ,Name [name]
                                    ,YearOfRelease [YearOfRelease]
                                    ,Plot [Plot]
                                    ,ProducerId [ProducerId]
                                    ,CoverImage [CoverImage]
                                FROM [dbo].[Movies]";
                return connection.Query<Movie>(sql);
            }
        }

        /// <inheritdoc/>
        public void Update(int id, Movie movie, List<int> actorIds, List<int> genreIds)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString.IMDBDb))
            {
                const string sql = @"usp_UpdateMovie";
                var values = new
                {
                    movie.Id,
                    movie.Name,
                    movie.YearOfRelease,
                    movie.Plot,
                    movie.ProducerId,
                    movie.CoverImage,
                    ActorIds = string.Join(',', actorIds),
                    GenreIds = string.Join(',', genreIds)
                };
                connection.Execute(sql, values, commandType: CommandType.StoredProcedure);
            }
        } 
    }
}
