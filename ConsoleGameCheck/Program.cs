using System;
using GameLogic;

namespace ConsoleGameCheck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();


            var state = game.GetGameState();

            game.ShowMessage = ShowMessage;
            game.AskQuestion = AskQuestion;
            game.AskUserEnter = AskUserEnter;
            game.AskLoadGame = AskLoadGame;

            while (state != GameState.CloseGame)
            {
                UpdateGui(state.ToString());
                game.NextStep();
                state = game.GetGameState();
            }
            
            UpdateGui(state.ToString());
            game.NextStep();

        }

        private static Save AskLoadGame(Save[] options)
        {
            return new Save();
        }

        private static string AskUserEnter(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.ResetColor();
            return Console.ReadLine();
        }

        private static int AskQuestion(string question, string[] options)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(question);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Blue;

            int i = 1;
            foreach(var option in options)
            {
                Console.WriteLine($"{i} - {option}");
                i++;
            }

            int answer = -1;

            while (answer <= 0 || answer > options.Length)
            {
                int.TryParse(Console.ReadLine(), out answer);
            }

            Console.ResetColor();

            return answer - 1;
        }

        private static void ShowMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private static void UpdateGui(string topTextHeader)
        {
            Console.Clear();

            Span<char> topText = stackalloc char[80];
            topText.Fill('*');

            int lenght = topTextHeader.Length;
            int leftOffset = 80 / 2 - lenght / 2;
            int rightOffset = (80 / 2) + lenght / 2 + (lenght % 2 == 0 ? 0 : 1);

            topText[leftOffset - 1] = ' ';
            topText[rightOffset] = ' ';

            for (int i = 0; i < lenght; i++)
            {
                topText[leftOffset + i] = topTextHeader[i];
            }

            for(int i = 0; i < 80; i++)
            {
                Console.Write(topText[i]);
            }
            Console.WriteLine();
        }
    }
}
