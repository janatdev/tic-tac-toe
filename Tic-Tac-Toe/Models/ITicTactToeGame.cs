using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe.Models
{
    public interface ITicTactToeGame
    {
        List<char> BoardGame { get; set; }
        bool DoesPlayerWinWithPlay(char j, int index);
    }
}
