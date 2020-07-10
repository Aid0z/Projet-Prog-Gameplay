using System;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerScript : MonoBehaviour
{
    private void Update()
    {
        List<PlayerModule> playerModules = TAccessor<PlayerModule>.Instance().GetAllModules();
        List<EnemyModule> enemyModules = TAccessor<EnemyModule>.Instance().GetAllModules();
        int playerNb = playerModules.Count;
        int enemyNb = enemyModules.Count;
        
        if (playerNb > 0 && enemyNb > 0)
        {
            for (int i = 0; i < enemyNb; i++)
            {
                for (int j = 0; j < playerNb; j++)
                {
                    if (enemyModules[i].collider.bounds
                        .Intersects(playerModules[j].collider.bounds))
                    {
                        int score = TAccessor<PlayerModule>.Instance().GetModule(j).worth;
                        TAccessor<PlayerModule>.Instance().RemoveModule(j);
                        ScoreAccessor.Instance().AddToEnemyScore(score);
                        Debug.Log("Players : " + ScoreAccessor.Instance().GetPlayerScore() + "   Enemies : " + ScoreAccessor.Instance().GetEnemyScore());
                    }
                }
            }
        }
    }
}