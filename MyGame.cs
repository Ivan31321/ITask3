using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITask3
{
    internal class MyGame
    {
        public List<string> moves;
        public MyGame(List<string> Moves) {
            this.moves = Moves;
        }
        public int MakePCMove()
        {
            Random randomizer = new Random();
            var pcChoice = randomizer.Next(moves.Count);
            return pcChoice;
        }
        public int MakePLMove()
        {
            Console.Write("Enter your move: ");
            var answer = Console.ReadLine();
            if (answer == "?")return -1;
            int plChoice;
            try
            {
                plChoice = Convert.ToInt32(answer);
            }
            catch (Exception)
            {
                return -2;
            }
            return plChoice;
        }
        public void ShowMenu()
        {
            int moveIndex = 1;
            Console.WriteLine("Available moves:");
            foreach (string move in moves)
            {
                Console.WriteLine($"{moveIndex++} - {move}");
            }
            Console.WriteLine("0 - exit");
            Console.WriteLine("? - help");
        }
        public bool ErrorCheck()
        {
            if (moves.Count % 2 != 1 || moves.Count < 3 
                || moves.GroupBy(v => v).Where(g => g.Count() > 1).Select(g => g.Key).Count() != 0) return true;
            else return false;
        }
        public string FindWinner(int plChoice,int pcChoice)
        {
            string answer = "";
            if (pcChoice == plChoice) answer = "Draw";
            else if ((plChoice < pcChoice && pcChoice - plChoice <= (moves.Count - 1) / 2) ||
                (plChoice > pcChoice && moves.Count - plChoice + pcChoice <= (moves.Count - 1) / 2))
            {
                answer = "You win!";
            }
            else answer = "You lose(";
            return answer;
        }
        public string ErrorAnswer()
        {
            string answer = "";
            if (moves.Count % 2 != 1) answer = "The number of combinations must be odd\n" +
                    "Example: rock scissors paper";
            else if (moves.Count < 3) answer = "The number of combinations must be more than 2\n" +
                    "Example: rock scissors paper";
            else if (moves.GroupBy(v => v).Where(g => g.Count() > 1).Select(g => g.Key).Count() != 0) answer = "All lines must be unique\n" +
                    "Example: rock scissors paper";
            return answer;
        }
    }
}
