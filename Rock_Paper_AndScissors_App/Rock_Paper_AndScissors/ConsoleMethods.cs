using ConsoleHelperLibrary;
using RPS_Library.Enums;
using RPS_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_AndScissors
{
    public static class ConsoleMethods
    {
        public static void WelcomeMesasge()
        {
            @"
 .----------------.  .----------------.  .----------------. 
| .--------------. || .--------------. || .--------------. |
| |  _______     | || |   ______     | || |    _______   | |
| | |_   __ \    | || |  |_   __ \   | || |   /  ___  |  | |
| |   | |__) |   | || |    | |__) |  | || |  |  (__ \_|  | |
| |   |  __ /    | || |    |  ___/   | || |   '.___`-.   | |
| |  _| |  \ \_  | || |   _| |_      | || |  |`\____) |  | |
| | |____| |___| | || |  |_____|     | || |  |_______.'  | |
| |              | || |              | || |              | |
| '--------------' || '--------------' || '--------------' |
 '----------------'  '----------------'  '----------------' 
".Center().PrintToConsole();
            "Welcome to my Rock, paper and scissors App.".Center().PrintToConsole();
            Console.WriteLine();
            "Hope you enjoy!!".Center().PrintToConsole();
            "===========================================".Center().PrintToConsole();
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void Instructions()
        {
            ">This game will be a game will consist of 3 rounds.".PrintToConsole();
            ">You will play against the computer for now... ".PrintToConsole();
            Console.WriteLine();

        }

        public static void AskToPlay(PlayerModel activePlayer, PlayerModel opponent)
        {
            
            while (true)
            {
                string output = "Do you want to Play:) or Exit:( (Yes/No): ".RequestString();
                if (output.Trim().ToLower() == "yes")
                {
                    PlayGame(activePlayer, opponent);
                    $"Score: {activePlayer.CurrentScore++}".Center().PrintToConsole();
                    break;
                }
                else if (output.Trim().ToLower() == "no")
                {
                    Console.Clear();
                    "See you later".Center().PrintToConsole();
                    break;
                }
            }
        }

        public static void PlayGame(PlayerModel activePlayer, PlayerModel opponent)
        {
            for (int i = 0; i < 3; i++)
            {
                (string text, HandEnum move) userMove = RequestUserMove(activePlayer);
                (string text, HandEnum move) oppMove = GetOpponentMove(opponent);

                //Change to Green and Red
                Console.WriteLine();
                "You played the move: ".PrintToConsole();
                GetGrnColor();
                $"{userMove.text}".PrintToConsole();
                Console.ResetColor();

                Console.WriteLine();
                "The opponent played the move: ".PrintToConsole();
                GetRedColor();
                $"{oppMove.text}".PrintToConsole();
                Console.ResetColor();

                if ((userMove.move == HandEnum.Paper && oppMove.move == HandEnum.Rock)
                    || (userMove.move == HandEnum.Rock && oppMove.move == HandEnum.Scissors)
                    || (userMove.move == HandEnum.Scissors && oppMove.move == HandEnum.Paper))
                {
                    Console.WriteLine();
                    GetGrnColor();
                    "You won the round".PrintToConsole();
                    activePlayer.CurrentScore++;
                    Console.ResetColor();
                }
                else if (userMove.move == oppMove.move)
                {
                    Console.WriteLine();
                    "It is a tie this round".PrintToConsole();
                }
                else
                {
                    Console.WriteLine();
                    GetRedColor();
                    "You lost this round".PrintToConsole();
                    Console.ResetColor();
                }
            }

            Console.ReadKey();

            if (activePlayer.CurrentScore < 2)
            {
                Console.Clear();
                "You lost!!".Center().PrintToConsole();
            }
            else if (activePlayer.CurrentScore >= 2)
            {
                Console.Clear();
                "You won!!".Center().PrintToConsole();
            }
        }

        public static (string userMoveText, HandEnum UserMove) RequestUserMove(PlayerModel model)
        {
            HandEnum output = GetEnum();
            return (model.GetHandMove(output), output);
        }

        public static (string, HandEnum) GetOpponentMove(PlayerModel model)
        {
            return model.GetRndMove();
        }

        public static HandEnum GetEnum()
        {
            Console.WriteLine();
            string move = "What is your move(Paper/Rock/Scissors): ".RequestString();
            switch (move.Trim().ToLower())
            {
                case "paper":
                    return HandEnum.Paper;
                    
                case "rock":
                    return HandEnum.Rock;

                case "scissors":
                    return HandEnum.Scissors;
                    
                default:
                    throw new InvalidDataException("Unknown Move");
            }
        }

        public static void GetGrnColor()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public static void GetRedColor()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

    }
}
