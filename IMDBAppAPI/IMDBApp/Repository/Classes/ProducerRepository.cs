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
    public class ProducerRepository : IProducerRepository
    {
        private readonly ConnectionString _connectionString;

        public ProducerRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString.Value;
        }

        /// <inheritdoc/>
        public int Add(Producer producer)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString.IMDBDb))
            {
                const string sql = @"
                        INSERT INTO [dbo].[Producers] (
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
                    producer.Name,
                    producer.Bio,
                    producer.Gender,
                    producer.Dob
                });
            }
        }

        /// <inheritdoc/>
        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString.IMDBDb))
            {
                const string sql = @"
                        DELETE
                        FROM [dbo].[Producers]
                        WHERE Id = @Id";
                connection.Execute(sql, new { Id = id });
            }
        }

        /// <inheritdoc/>
        public Producer Get(int id)
        {
            using (var connection = new SqlConnection(_connectionString.IMDBDb))
            {
                const string sql = @"
                        SELECT Id [Id]
                            ,Name [Name]
                            ,Bio [Bio]
                            ,Gender [Gender]
                            ,Dob [Dob]
                        FROM [dbo].[Producers]
                        WHERE Id = @Id";
                return connection.QuerySingle<Producer>(sql, new { Id = id });
            }
        }

        /// <inheritdoc/>
        public IEnumerable<Producer> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString.IMDBDb))
            {
                const string sql = @"
                        SELECT Id [Id]
                            ,Name [Name]
                            ,Bio [Bio]
                            ,Gender [Gender]
                            ,Dob [Dob]
                        FROM [dbo].[Producers]";
                return connection.Query<Producer>(sql);
            }
        }

        public Producer GetByMovieId(int movieId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString.IMDBDb))
            {
                const string sql = @"
                                SELECT P.Id [Id]
                                    ,P.Name [Name]
                                    ,P.Bio [Bio]
                                    ,P.Gender [Gender]
                                    ,P.Dob [Dob]
                                FROM [dbo].[Movies] M
                                INNER JOIN [dbo].[Producers] P ON M.ProducerId = P.Id
                                WHERE M.Id = @Id";
                return connection.QuerySingle<Producer>(sql, new { Id = movieId });
            }
        }

        /// <inheritdoc/>
        public void Update(int id, Producer producer)
        {
            using (var connection = new SqlConnection(_connectionString.IMDBDb))
            {
                const string sql = @"
                        UPDATE [dbo].[Producers]
                        SET Name = @Name
                            ,Bio = @Bio
                            ,Gender = @Gender
                            ,Dob = @Dob
                            ,UpdatedAt = GETDATE()
                        WHERE Id = @Id";
                connection.Execute(sql, new
                {
                    producer.Name,
                    producer.Bio,
                    producer.Gender,
                    producer.Dob,
                    id
                });
            }
        }
    }
}
