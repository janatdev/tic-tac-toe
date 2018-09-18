using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tic_Tac_Toe.Models;

namespace Tic_Tac_Toe.Controllers
{
    public class HomeController : Controller
    {     
        // GET: Home
        public ActionResult Index()
        {
            TicTacToeGame game = GetActiveGame();
            return View(game);
        }

        [HttpPost]
        public ActionResult Index(int square)
        {
            TicTacToeGame game = GetActiveGame(square);
            PlaySquare(game, square);
            return RedirectToAction("Index");
        }

        private void PlaySquare(TicTacToeGame game, int square)
        {
            if (square == -1)
            {
                return;
            }

            if (game.BoardGame[square] == ' ')
            {
                // Play 'X' where player chose
                game.BoardGame[square] = 'X';

                // If game is not over, find a play for 'O'
                if (!game.IsGameOver)
                {
                    game.BoardGame[GetOPlayIndex(game)] = 'O';
                }
            }
        }

        private int GetOPlayIndex(TicTacToeGame game)
        {
            int index = 4;

            // Check for winning plays for O. If there is one, win the game.
            for (int i = 0; i < 9; i++)
            {
                if (game.BoardGame[i] == ' ' && game.DoesPlayerWinWithPlay('O', i))
                {
                    return i;
                }
            }

            // Check for winning plays for X. If there is one, block it.
            for (int i = 0; i < 9; i++)
            {
                if (game.BoardGame[i] == ' ' && game.DoesPlayerWinWithPlay('X', i))
                {
                    return i;
                }
            }

            // Check for available spaces. (i + 4) % 9 steps through starting at the middle square
            for (int i = 0; i < 9; i++)
            {
                if (game.BoardGame[(i + 4) % 9] == ' ')
                {
                    return (i + 4) % 9;
                }
            }

            return index;
        }

        private TicTacToeGame GetActiveGame(int square = 0)
        {
            TicTacToeGame game = null;

            if (Session["game"] == null || square == -1)
            {
                game = new TicTacToeGame();
                Session["game"] = game;
            }
            else
            {
                game = Session["game"] as TicTacToeGame;
            }

            return game;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}