using MySql.Data.MySqlClient;
using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splek.Repository.Repository
{
    public class GameRepository
    {

        public void Insert(Models.Game game)
        {
            // Create a connection to the database
            using (var connection = new MySqlConnection(MainConnections.connectionString))
            {
                connection.Open();
                // Create a command to execute SQL queries
                var command = connection.CreateCommand();
                // Insert a game into the database
                command.CommandText = "INSERT INTO games (title, body, user_id, likes, dislikes, created_at) VALUES (@title, @body, @userId, @likes, @dislikes, @timestamp)";
                command.Parameters.AddWithValue("@title", game.Title);
                command.Parameters.AddWithValue("@body", game.Body);
                command.Parameters.AddWithValue("@userId", game.UserId);
                command.Parameters.AddWithValue("@likes", game.Likes);
                command.Parameters.AddWithValue("@dislikes", game.Dislikes);
                command.Parameters.AddWithValue("@timestamp", DateTime.Now);

                command.ExecuteNonQuery();
            }
        }

        public List<Models.Game> GetAllGamesFromDatabase()
        {
            List<Models.Game> games = new List<Models.Game>();
            // Create a connection to the database
            using (var connection = new MySqlConnection(MainConnections.connectionString))
            {
                connection.Open();
                // Create a command to execute SQL queries
                var command = connection.CreateCommand();
                // Select all games from the database
                command.CommandText = "SELECT * FROM games";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Models.Game game = new Models.Game
                        {
                            Id = reader.GetInt32("id"),
                            Title = reader.GetString("title"),
                            Body = reader.GetString("body"),
                            UserId = reader.GetInt32("user_id"),

                        };
                        games.Add(game);
                    }
                }
            }
            if (games.Count == 0)
            {
                throw new Exception("No games found in the database.");
            }
            else
            {
                return games;
            }
        }

        public Models.Game GetGameById(int id)
        {
            // Create a connection to the database
            using (var connection = new MySqlConnection(MainConnections.connectionString))
            {
                connection.Open();
                // Create a command to execute SQL queries
                var command = connection.CreateCommand();
                // Select a game by ID from the database
                command.CommandText = "SELECT * FROM games WHERE id = @id";
                command.Parameters.AddWithValue("@id", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Models.Game
                        {
                            Id = reader.GetInt32("id"),
                            Title = reader.GetString("title"),
                            Body = reader.GetString("body"),
                            UserId = reader.GetInt32("user_id"),
                            Likes = reader.GetInt32("likes"),
                            Dislikes = reader.GetInt32("dislikes"),
                            CreatedAt = reader.GetDateTime("created_at")
                        };
                    }
                    else
                    {
                        throw new Exception($"Game with ID {id} not found.");
                    }
                }
            }
        }

        public Models.Game GetGameByUserId(int UserID)
        {
            // Create a connection to the database
            using (var connection = new MySqlConnection(MainConnections.connectionString))
            {
                connection.Open();
                // Create a command to execute SQL queries
                var command = connection.CreateCommand();
                // Select a game by ID from the database
                command.CommandText = "SELECT * FROM games WHERE user_id = @user_id";
                command.Parameters.AddWithValue("@user_id", UserID);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Models.Game
                        {
                            Id = reader.GetInt32("id"),
                            Title = reader.GetString("title"),
                            Body = reader.GetString("body"),
                            UserId = reader.GetInt32("user_id"),
                            Likes = reader.GetInt32("likes"),
                            Dislikes = reader.GetInt32("dislikes"),
                            CreatedAt = reader.GetDateTime("created_at")
                        };
                    }
                    else
                    {
                        throw new Exception($"Game with User ID {UserID} not found.");
                    }
                }
            }
        }

        public void DeleteGame(int id)
        {
            // Create a connection to the database
            using (var connection = new MySqlConnection(MainConnections.connectionString))
            {
                connection.Open();
                // Create a command to execute SQL queries
                var command = connection.CreateCommand();
                // Delete a game by ID from the database
                command.CommandText = "DELETE FROM games WHERE id = @id";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }

        public Models.Game UpdateGame(Models.Game game)
        {
            // Create a connection to the database
            using (var connection = new MySqlConnection(MainConnections.connectionString))
            {
                connection.Open();
                // Create a command to execute SQL queries
                var command = connection.CreateCommand();
                // Update a game in the database
                command.CommandText = "UPDATE games SET title = @title, body = @body, user_id = @userId, likes = @likes, dislikes = @dislikes WHERE id = @id";
                command.Parameters.AddWithValue("@id", game.Id);
                command.Parameters.AddWithValue("@title", game.Title);
                command.Parameters.AddWithValue("@body", game.Body);
                command.Parameters.AddWithValue("@userId", game.UserId);
                command.Parameters.AddWithValue("@likes", game.Likes);
                command.Parameters.AddWithValue("@dislikes", game.Dislikes);
                command.ExecuteNonQuery();
            }


            // Return the updated game object
            return game;
        }
    }
}
