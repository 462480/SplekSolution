using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Splek.Repository.Models;
using Splek.Logic.Services;
using Splek.Repository.Repository;
using Splek.Controllers;
using Splek.Logic.DTO_s;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace Logic.Maincontroller.Tests
{
    [TestClass()]

    public class MainControllerTests
    {
        private readonly string c = "Server=localhost;Database=splek_db;Uid=root;Pwd=;";

        [TestMethod()]
        public void AddGametoDatabaseTest()
        {
            //Arrange
            Splek.Repository.Models.Game g = new ();
            g.Title = "unitTestSpel";
            g.Body = "Ik ben een spel - Dit spel is nooit zichtbaar";
            Splek.Repository.Models.User u = new ();
            u.Id = 27;
            g.User = u;


            //Act 
            //Create a new database connection
            using (var connection = new MySqlConnection(c))
            {
                connection.Open();
                // Create a command to execute SQL queries
                var SetCommand = connection.CreateCommand();
                // Insert a game into the database
                SetCommand.CommandText = "INSERT INTO games (title, body, user_id, created_at) VALUES (@title, @body, @userId, current_timestamp())";
                SetCommand.Parameters.AddWithValue("@title", g.Title);
                SetCommand.Parameters.AddWithValue("@body", g.Body);
                SetCommand.Parameters.AddWithValue("@userId", g.User.Id);

                SetCommand.ExecuteNonQuery();
            }

            using (var c2 = new MySqlConnection(c))
            {
                c2.Open();
                var getCommand = c2.CreateCommand();
                getCommand.CommandText = "SELECT * FROM games WHERE title = @title";
                getCommand.Parameters.AddWithValue("@title", "unitTestSpel");

                List<Game> games = new List<Game>();
                using (var reader = getCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Game game = new Game
                        {
                            Id = reader.GetInt32("id"),
                            Title = reader.GetString("title"),
                            Body = reader.GetString("body"),
                            UserId = reader.GetInt32("user_id"),
                        };
                        games.Add(game);
                    }
                }
                Assert.IsFalse(games.Count == 0);   
                Assert.IsTrue(games.Count == 1);
                Assert.IsFalse(games.Count > 1);
            }
            // Clean up: delete the test game from the database
            using (var c3 = new MySqlConnection(c))
            {
                c3.Open();
                var deleteCommand = c3.CreateCommand();
                deleteCommand.CommandText = "DELETE FROM games WHERE title = @title";
                deleteCommand.Parameters.AddWithValue("@title", "unitTestSpel");
                deleteCommand.ExecuteNonQuery();
            }

        }

        [TestMethod()]
        public void GetAllGamesFromDatabaseTest()
        {
            // Arrange
            GameRepository GameR = new GameRepository();
            GameService GameS = new GameService(GameR);
            GameController GameC = new GameController(GameS);

            var result = GameC.GetAllGames();

            Assert.IsNotNull(result);
        }


    }
}