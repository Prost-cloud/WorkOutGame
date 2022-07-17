using System;

namespace GameLogic
{
    public class Game
    {
        private Dificulty dificulty;
        private GameState gameState;

        private Character _Character;

        public Game()
        {
            gameState = GameState.SelectNewLoadGame;
        }

        private void SaveGame()
        {

        }

        private void LoadGame()
        {

        }

    }
}