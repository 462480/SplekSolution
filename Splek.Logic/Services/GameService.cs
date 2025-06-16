using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Org.BouncyCastle.Asn1.X509;
using Splek.Repository.Models;
using Splek.Repository.Repository;
using Splek.Logic.DTO_s;



namespace Splek.Logic.Services
{
   public class GameService
    {
        private readonly GameRepository _gameRepo;

        public GameService(GameRepository gameRepo)
        {
            _gameRepo = gameRepo;
        }

        public void CreateGame(DTO_s.CreateRequest request)
        {
            var game = new Repository.Models.Game
            {
                Title = request.Title,
                Body = request.Body,
                UserId = request.UserId,
                Likes = 0,
                Dislikes = 0,


            };

            _gameRepo.Insert(game);
        }

        public List<DTO_s.CreateResponse> GetAllGames()
        {
            List<Repository.Models.Game> games = _gameRepo.GetAllGamesFromDatabase();
            List<DTO_s.CreateResponse> response = new List<DTO_s.CreateResponse>();

            foreach (var game in games)
            {
                response.Add(new DTO_s.CreateResponse
                {
                    Title = game.Title,
                    Body = game.Body,
                    UserId = game.UserId,
                    Likes = game.Likes,
                    Dislikes = game.Dislikes
                });
            }

            return response;
        }

        public CreateResponse GetGameByID(int id)
        {
            Repository.Models.Game game = _gameRepo.GetGameById(id);
            if (game == null)
            {
                return null;
            }
            return new CreateResponse
            {
                Title = game.Title,
                Body = game.Body,
                UserId = game.UserId,
                Likes = game.Likes,
                Dislikes = game.Dislikes
            };
        }

        public CreateResponse GetGameByUserID(int UserID)
        {
            Repository.Models.Game game = _gameRepo.GetGameByUserId(UserID);
            if (game == null)
            {
                return null;
            }
            return new CreateResponse
            {
                Title = game.Title,
                Body = game.Body,
                UserId = game.UserId,
                Likes = game.Likes,
                Dislikes = game.Dislikes
            };
        }

        public void DeleteGame(int id)
        {
            _gameRepo.DeleteGame(id);
        }

        public CreateResponse UpdateGame(DTO_s.CreateRequest request)
        {
            var game = new Repository.Models.Game
            {
                Id = request.Id,
                Title = request.Title,
                Body = request.Body,
                UserId = request.UserId,
            };
            game = _gameRepo.UpdateGame(game);

            return new CreateResponse
            {
                Title = game.Title,
                Body = game.Body,
                UserId = game.UserId,
                Likes = game.Likes,
                Dislikes = game.Dislikes
            };
        }
    }


}
