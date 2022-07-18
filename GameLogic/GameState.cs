namespace GameLogic
{
    public enum GameState
    {
        GameStart,              // Game just init
        SelectNewLoadGame,      // 1st step after GameStart
        SelectDificulty,        // Step after user select new game
        Idle,                   // Used whenever training is end or not started
        TrainingStart,          // Show info about training and user can turn on/off timer
        TrainingInProgress,     // Show animation for training, if timer on count down and make sound graphic warn  
        TrainingDone,           // Show after training message 
        CloseGame               // Close Game
    }
}