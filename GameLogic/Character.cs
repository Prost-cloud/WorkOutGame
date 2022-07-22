namespace GameLogic
{
    internal class Character
    {
        private string m_Name;
        //private int m_Level;


        public string Name { get; private set; }

        public int Strenght { get; private set; }
        public int Agility { get; private set; }
        public int Endurance { get; private set; }

        public Character(string name) : this(name, 5, 5, 5)
        {
            Name = name;
        }

        public Character(string name, int strenght, int agility, int endurance)
        {
            Name = name;
            //m_Level = level;
            Strenght = strenght;
            Agility = agility;
            Endurance = endurance;
        }
    }
}