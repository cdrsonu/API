using Dapper;
using IMDB.Repository.Interfaces;
using IMDBApp.Models.Classes;
using IMDBAppAPI;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace IMDBApp.Repository.Classes
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ConnectionString _connectionString;

        public GenreRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString.Value;
        }

        /// <inheritdoc/>
        public int Add(Genre genre)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString.IMDBDb))
            {
                const string sql = @"
                        INSERT INTO [dbo].[Genres] (
                            Name
                            ,CreateAt
                            )
                        OUTPUT INSERTED.Id
                        VALUES (
                            @Name
                            ,GETDATE()
                            )";
                return connection.QuerySingle<int>(sql, new { genre.Name });
            }
        }

        /// <inheritdoc/>
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString.IMDBDb))
            {
                const string sql = @"
                        DELETE
                        FROM [dbo].[Genres]
                        WHERE Id = @Id";
                connection.Execute(sql, new { id });
            }
        }

        /// <inheritdoc/>
        public Genre Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString.IMDBDb))
            {
                const string sql = @"
                        SELECT Id [Id]
                            ,Name [Name]
                        FROM [dbo].[Genres]
                        WHERE Id = @Id";
                return connection.QuerySingle<Genre>(sql, new { id });
            }
        }

        /// <inheritdoc/>
        public IEnumerable<Genre> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString.IMDBDb))
            {

                const string sql = @"
                        SELECT Id [Id]
                            ,Name [Name]
                        FROM [dbo].[Genres]";
                return connection.Query<Genre>(sql);
            }
        }

        public IEnumerable<Genre> GetByMovieId(int movieId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString.IMDBDb))
            {
                const string sql = @"
                                SELECT Id [Id]
                                    ,Name [Name]
                                FROM [dbo].[Genres] G
                                INNER JOIN [dbo].[GenreMovies] GM ON G.Id = GM.GenreId
                                WHERE GM.MovieId = @MovieId";
                return connection.Query<Genre>(sql, new { movieId });
            }
        }

        /// <inheritdoc/>
        public void Update(int id, Genre genre)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString.IMDBDb))
            {
                const string sql = @"
                        UPDATE [dbo].[Genres]
                        SET Name = @Name
                            ,UpdatedAt = GETDATE()
                        WHERE Id = @Id";
                int rowsEffects = connection.Execute(sql, new
                {
                    genre.Name,
                    id
                });
            }
        }
    }
}
