using System;

namespace GameLogic
{
internal enum GameState
{
    MainMenu,
    TrainingStart,
    TrainingEnd,
    TrainingDone,

}
    internal class Character
    {
        private string m_Name;
        private int m_Level;

        public int Strenght { get; set; }
        public int Agility { get; set; }
        public int Endurance { get; set; }


    }
    public class Game
    {
        Dificulty Dificulty { get; set; }
        private GameState state;


        Character _Character;

        public Game()
        {

        }
    }
}