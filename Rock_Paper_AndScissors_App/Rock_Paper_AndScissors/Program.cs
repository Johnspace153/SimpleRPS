
using Rock_Paper_AndScissors;
using RPS_Library.Models;

PlayerModel activePlayer = new PlayerModel();
PlayerModel Oponnent = new PlayerModel();

ConsoleMethods.WelcomeMesasge();
ConsoleMethods.Instructions();
ConsoleMethods.AskToPlay(activePlayer, Oponnent);













Console.ReadLine();