using System;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetUpdater : MonoBehaviour
{
    /*public void SystemUpdate()
    {
        
    }*/

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
                GameObject playerGameObject = TAccessor<PlayerModule>.Instance().GetGameObject(0);
                float minDist = Vector3.Distance(playerGameObject.transform.position, enemyGameObject.transform.position);
                enemyModules[i].destination = playerGameObject.transform.position;
                
                for (int j = 1; j < playerNb; j++)
                {
                    playerGameObject = TAccessor<PlayerModule>.Instance().GetGameObject(j);
                    float tmpDist = Vector3.Distance(playerGameObject.transform.position,
                        enemyGameObject.transform.position);
                    if (tmpDist < minDist)
                    {
                        enemyModules[i].destination = playerGameObject.transform.position;
                        minDist = tmpDist;
                    }
                }

                enemyGameObject.GetComponent<Rigidbody>().velocity =
                    Vector3.Normalize(enemyModules[i].destination - enemyGameObject.transform.position);
            }
        }
    }
}