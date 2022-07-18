using System;
using System.Collections.Generic;
using System.IO;

namespace GameLogic
{
    public class Game
    {
        private Dificulty dificulty;
        private GameState gameState;

        private Character _Character;

        private Dictionary<GameState, Delegate> _Actions;

        public Game()
        {
            gameState = GameState.GameStart;

            _Actions.Add(GameState.GameStart, new Action(ChooseLoadNewGame));
        }

        public void NextStep()
        {

        }

        private void ChooseLoadNewGame()
        {

        }

        private void SaveGame()
        {
            throw new NotImplementedException();
        }

        private void LoadGame()
        {
            throw new NotImplementedException();
        }

        public GameState GetGameState()
        {
            return gameState;
        }

        public Dificulty GetDificulty()
        {
            return dificulty;
        }

        public string[] GetAllSaves()
        {
            return new string[0];
        }
    }
}