public class ScoreAccessor //pas eu le temps de faire les modifications nécessaires pour supprimer ScoreAccessor
{
    private static ScoreAccessor _singleton = null;
    private static ScoreModule _module;

    public static ScoreAccessor Instance()
    {
        if (_singleton == null)
        {
            _singleton = new ScoreAccessor();
            _module = new ScoreModule();
        }

        return _singleton;
    }

    public int GetPlayerScore()
    {
        return _module.playerScore;
    }

    public int GetEnemyScore()
    {
        return _module.enemyScore;
    }

    public void AddToPlayerScore(int points)
    {
        _module.playerScore += points;
    }

    public void AddToEnemyScore(int points)
    {
        _module.enemyScore += points;
    }
}