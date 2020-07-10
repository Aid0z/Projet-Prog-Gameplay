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
                for (int j = 0; j < edibleNb; j++)
                {
                    if (playerModules[i].collider.bounds
                        .Intersects(edibleModules[i].collider.bounds))
                    {
                        int score = TAccessor<EdibleModule>.Instance().GetModule(j).worth;
                        TAccessor<EdibleModule>.Instance().RemoveModule(j);
                        ScoreAccessor.Instance().AddToPlayerScore(score);
                        Debug.Log("Players : " + ScoreAccessor.Instance().GetPlayerScore() + "   Enemies : " + ScoreAccessor.Instance().GetEnemyScore());
                    }
                }
            }
        }
    }
}