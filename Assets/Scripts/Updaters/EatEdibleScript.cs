using System;
using System.Collections.Generic;
using UnityEngine;

public class EatEdibleScript : MonoBehaviour
{
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
                
                for (int j = 0; j < edibleNb; j++)
                {
                    GameObject edibleGameObject = TAccessor<EdibleModule>.Instance().GetGameObject(j);
                    if (edibleGameObject != null && playerGameObject.GetComponent<Collider>().bounds
                        .Intersects(edibleGameObject.GetComponent<Collider>().bounds))
                    {
                        TAccessor<EdibleModule>.Instance().RemoveModule(j);
                        ScoreAccessor.Instance().AddToPlayerScore(10);
                    }
                }
            }
        }
    }
}