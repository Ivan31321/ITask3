using System.Security.Cryptography;
using System.Text;
namespace ITask3
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> moves = args.ToList();
            MyGame game = new MyGame(moves);
            HMACGenerate hMACGenerate = new HMACGenerate();
            if (game.ErrorCheck()) Console.WriteLine(game.ErrorAnswer());
            else
            {
                while (true)
                {
                    byte[] key = hMACGenerate.GenerateKey();
                    int pcChoice = game.MakePCMove();
                    string hash = hMACGenerate.HMACHASH(moves[pcChoice],key);
                    Console.WriteLine($"HMAC: {hash}");
                    bool EndAsking = true;  
                    while (EndAsking)
                    {
                        game.ShowMenu();
                        int plChoice = game.MakePLMove();
                        if (plChoice == -1) Help.ShowHelp(moves);
                        else if (plChoice == 0) return;
                        else if(plChoice < 0 || plChoice > moves.Count) Console.WriteLine("Uncorrect input");
                        else
                        {
                            plChoice -= 1;
                            Console.WriteLine($"Your move: {moves[plChoice]}");
                            string moveResult = game.FindWinner(plChoice, pcChoice);
                            Console.WriteLine(moveResult);
                            Console.WriteLine($"Computer choice: { moves[pcChoice] }");
                            Console.WriteLine($"HMAC key: {BitConverter.ToString(key).Replace("-",String.Empty).ToLower()}");
                            EndAsking = false;
                        }
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey(true);
                    Console.Clear();
                }
            }
        }
    }
}