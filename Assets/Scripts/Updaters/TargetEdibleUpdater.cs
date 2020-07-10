using System;
using System.Collections.Generic;
using UnityEngine;

public class TargetEdibleUpdater : MonoBehaviour
{
    /*public void SystemUpdate()
    {
        
    }*/

    private void Update()
    {
        List<PlayerModule> playerModules = TAccessor<PlayerModule>.Instance().GetAllModules();
        List<EdibleModule> edibleModules = TAccessor<EdibleModule>.Instance().GetAllModules();
        int playerNb = playerModules.Count;
        int edibleNb = edibleModules.Count;

        if (playerNb > 0 && edibleNb > 0)
        {
            for (int i = 0; i < playerNb; i++)
            {
                float minDist = Vector3.Distance(playerModules[i].transform.position, edibleModules[0].transform.position);
                playerModules[i].destination = edibleModules[0].transform.position;
                
                for (int j = 1; j < edibleNb; j++)
                {
                    float tmpDist = Vector3.Distance(playerModules[i].transform.position,
                        edibleModules[j].transform.position);
                    if (tmpDist < minDist)
                    {
                        playerModules[i].destination = edibleModules[j].transform.position;
                        minDist = tmpDist;
                    }
                }

                playerModules[i].rigidbody.velocity =
                    Vector3.Normalize(playerModules[i].destination - playerModules[i].transform.position);
            }
        }
    }
}