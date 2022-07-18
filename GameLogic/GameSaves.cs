using System.Collections.Generic;

namespace GameLogic
{
    public class GameSaves
    {
        private Dictionary<string, Save>[] saves;
        private IFileManager fileManager;
    } 
}