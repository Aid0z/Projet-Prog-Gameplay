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
                GameObject playerGameObject = TAccessor<PlayerModule>.Instance().GetGameObject(i);
                GameObject edibleGameObject = TAccessor<EdibleModule>.Instance().GetGameObject(0);
                float minDist = Vector3.Distance(playerGameObject.transform.position, edibleGameObject.transform.position);
                playerModules[i].destination = edibleGameObject.transform.position;
                
                for (int j = 1; j < edibleNb; j++)
                {
                    edibleGameObject = TAccessor<EdibleModule>.Instance().GetGameObject(j);
                    float tmpDist = Vector3.Distance(playerGameObject.transform.position,
                        edibleGameObject.transform.position);
                    if (tmpDist < minDist)
                    {
                        playerModules[i].destination = edibleGameObject.transform.position;
                        minDist = tmpDist;
                    }
                }

                playerGameObject.GetComponent<Rigidbody>().velocity =
                    Vector3.Normalize(playerModules[i].destination - playerGameObject.transform.position);
            }
        }
    }
}