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
                float minDist = Vector3.Distance(playerModules[i].transform.position, enemyModules[0].transform.position);
                enemyModules[i].destination = playerModules[0].transform.position;
                
                for (int j = 1; j < playerNb; j++)
                {
                    float tmpDist = Vector3.Distance(playerModules[i].transform.position,
                        enemyModules[i].transform.position);
                    if (tmpDist < minDist)
                    {
                        enemyModules[i].destination = playerModules[i].transform.position;
                        minDist = tmpDist;
                    }
                }

                enemyModules[i].rigidbody.velocity =
                    Vector3.Normalize(enemyModules[i].destination - enemyModules[i].transform.position);
            }
        }
    }
}