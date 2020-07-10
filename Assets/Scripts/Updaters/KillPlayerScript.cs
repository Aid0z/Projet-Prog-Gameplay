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
                GameObject enemyGameObject = TAccessor<EnemyModule>.Instance().GetGameObject(i);
                
                for (int j = 0; j < playerNb; j++)
                {
                    GameObject playerGameObject = TAccessor<PlayerModule>.Instance().GetGameObject(j);
                    if (playerGameObject != null && enemyGameObject.GetComponent<Collider>().bounds
                        .Intersects(playerGameObject.GetComponent<Collider>().bounds))
                    {
                        TAccessor<PlayerModule>.Instance().RemoveModule(j);
                        ScoreAccessor.Instance().AddToEnemyScore(10);
                    }
                }
            }
        }
    }
}