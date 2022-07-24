using System;
using System.Collections.Generic;
using System.IO;

namespace GameLogic
{
    public class Game
    {
        public delegate void ShowMessageDelegate(string message);
        public delegate int AskQuestionDelegate(string question, string[] options);
        public delegate Save AskLoadGameDelegate(Save[] options);
        public delegate string AskUserEnterDelegate(string message);

        public ShowMessageDelegate ShowMessage;
        public AskQuestionDelegate AskQuestion;
        public AskLoadGameDelegate AskLoadGame;
        public AskUserEnterDelegate AskUserEnter;

        private Dificulty dificulty;
        private GameState gameState;
        private int saveSlot;

        private Dictionary<GameState, Action> _actions;

        private Character _Character;

        public GameState GetGameState() => gameState;
        public Dificulty GetDificulty() => dificulty;

        public Game()
        {
            gameState = GameState.GameStart;

            _actions = new Dictionary<GameState, Action>();
            _actions.Add(GameState.GameStart, GameStart);
            _actions.Add(GameState.SelectNewLoadGame, ChooseLoadNewGame);
            _actions.Add(GameState.CreateNewGame, CreateNewGame);
            _actions.Add(GameState.Idle, GameIdle);
            _actions.Add(GameState.CloseGame, CloseGame);
        }

        private void CloseGame()
        {
            ShowMessage("Closing game");
        }

        private void GameIdle()
        {
            ShowMessage("This is game idle");
            AskQuestion("Do u like coffee?", new[] { "Yes", "No" });
            gameState = GameState.CloseGame;
        }

        public void NextStep()
        {
            _actions[gameState].Invoke();
        }

        private void GameStart()
        {
            int answer = AskQuestion("Let's play!", new[] { "New game", "Load game", "Exit" });
            if (answer == 0)
            {
                gameState = GameState.CreateNewGame;
            }
            else if(answer == 1)
            {
                gameState = GameState.SelectNewLoadGame;
            }
            else if (answer == 2)
            {
                gameState = GameState.CloseGame;
            }
        }


        private void ChooseLoadNewGame()
        {
            throw new NotImplementedException();
        }

        private void CreateNewGame()
        {
            string playerName = AskUserEnter("What is your name?");
            _Character = new Character(playerName);

            int selectedDificulty = AskQuestion("How hard do u wonna training?", new[] { "Easy", "Normal", "Hard" });
            int isUsingTimer = AskQuestion("Do you want to use timer on some training?", new[] { "Yes", "No" });

            selectedDificulty = selectedDificulty == 0 ? 1 : selectedDificulty * 2;
            isUsingTimer = isUsingTimer == 1 ? 0 : 8;

            dificulty = (Dificulty)(selectedDificulty | isUsingTimer);

            saveSlot = AskQuestion("Select save slot", new[] { "1", "2", "3" });

            gameState = GameState.Idle;
        }

        private void SaveGame()
        {
            throw new NotImplementedException();
        }

        private void LoadGame()
        {
            throw new NotImplementedException();
        }

        public Save[] GetAllSaves()
        {
            return new Save[0];
        }
    }
}