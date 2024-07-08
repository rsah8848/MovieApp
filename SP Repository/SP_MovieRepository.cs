using IdentityMovie.Interface;
using IdentityMovie.Models;
using IdentityMovie.Models.ViewModel;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Security.AccessControl;

namespace IdentityMovie.SP_Repository
{
    public class SP_MovieRepository : IMovieRepository
    {
        private readonly IConfiguration _configuration;

        private string connectionString;

        public SP_MovieRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("ApplicationDbContextConnection");
        }

        public bool DeleteMovie(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_DeleteMovie", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@MovieId", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                return true;
            }
        }

        List<SpMovie> IMovieRepository.SpGetAllMovies()
        {
            List<SpMovie> list = new List<SpMovie>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetAllMovies", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SpMovie movie = new SpMovie()
                            {
                                MovieId = (int)reader["MovieId"],
                                Title = (string)reader["Title"],
                                Description = (string)reader["Description"],
                                Photo = (string)reader["Photo"],
                                Years = (string)reader["Years"],
                                GenreName = (string)reader["GenreName"],
                                Name = (string)reader["Name"]
                            };
                            list.Add(movie);
                        }
                    }
                }
            }
            return list;
        }

        public Movie GetById(int MovieId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetMovieById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MovieId", MovieId);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Movie movie = new Movie()
                            {
                                MovieId = (int)reader["MovieId"],
                                Title = (string)reader["Title"],
                                Description = (string)reader["Description"],
                                Photo = (string)reader["Photo"],
                                YearId = (int)reader["YearId"],
                                GenreId = (int)reader["GenreId"],
                                CountryId = (int)reader["CountryId"]
                            };
                            return movie;
                        }
                    }
                }
                return null;
            }
        }

        public bool UpdateMovie(Movie movie)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdateMovie", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MovieId", movie.MovieId);
                    command.Parameters.AddWithValue("@Title", movie.Title);
                    command.Parameters.AddWithValue("@Description", movie.Description);
                    //command.Parameters.AddWithValue("@Photo", movie.Photo);
                    command.Parameters.AddWithValue("@YearId", movie.YearId);
                    command.Parameters.AddWithValue("@GenreId", movie.GenreId);
                    command.Parameters.AddWithValue("@CountryId", movie.CountryId);

                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }

            }
        }

        public List<Movie> GetAllMovies()
        {
            throw new NotImplementedException();
        }

        public bool AddMovie(Movie movie)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_InsertMovie", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Title", movie.Title);
                    command.Parameters.AddWithValue("@Description", movie.Description);
                    command.Parameters.AddWithValue("@Photo", movie.Photo);
                    command.Parameters.AddWithValue("@YearId", movie.YearId);
                    command.Parameters.AddWithValue("@GenreId", movie.GenreId);
                    command.Parameters.AddWithValue("@CountryId", movie.CountryId);

                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
            }
        }
    }
}
