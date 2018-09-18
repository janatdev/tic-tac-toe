using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tic_Tac_Toe.Models
{
    public class TicTacToeGame : ITicTactToeGame
    {
        public List<char> BoardGame { get; set; }

        public TicTacToeGame()
        {
            BoardGame = new List<char> { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        }

        public bool DoesPlayerWinWithPlay(char j, int index)
        {
            List<char> tempGameList = BoardGame.ToList();

            if (tempGameList[index] == ' ')
            {
                tempGameList[index] = j;
            }
            else
            {
                return false;
            }

            TicTacToeGame tempGame = new TicTacToeGame();
            tempGame.BoardGame = tempGameList;

            return tempGame.IsGameOver;
        }

        public bool IsGameOver
        {
            get
            {
                return (Winner != ' ' || !BoardGame.Contains(' '));
            }
        }

        public char Winner
        {
            get
            {
                char result = ' ';

                // check rows
                for (int x = 0; x < 3; x++)
                {
                    if (BoardGame[x * 3] == BoardGame[x * 3 + 1] && BoardGame[x * 3 + 1] == BoardGame[x * 3 + 2] && BoardGame[x * 3] != ' ')
                    {
                        return BoardGame[x * 3];
                    }
                }

                // check columns
                for (int y = 0; y < 3; y++)
                {
                    if (BoardGame[y] == BoardGame[y + 3] && BoardGame[y + 3] == BoardGame[y + 6] && BoardGame[y] != ' ')
                    {
                        return BoardGame[y];
                    }
                }

                // check diagonal down
                if (BoardGame[0] == BoardGame[4] && BoardGame[4] == BoardGame[8] && BoardGame[0] != ' ')
                {
                    return BoardGame[0];
                }

                // check diagonal up
                if (BoardGame[2] == BoardGame[4] && BoardGame[4] == BoardGame[6] && BoardGame[2] != ' ')
                {
                    return BoardGame[2];
                }

                return result;
            }
        }

    }
}