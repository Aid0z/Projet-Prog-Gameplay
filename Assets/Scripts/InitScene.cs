using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitScene : MonoBehaviour
{
    public List<GameObject> fruits;
    public bool randomFruits;
    public GameObject fruitPrefab;

    public List<GameObject> enemies;
    public bool randomEnemies;
    public GameObject enemyPrefab;

    public List<GameObject> players;
    public bool randomPlayers;
    public GameObject playerPrefab;

    private void Awake()
    {
        TAccessor<EdibleModule> edibleAccessor = TAccessor<EdibleModule>.Instance();
        TAccessor<EnemyModule> enemyAccessor = TAccessor<EnemyModule>.Instance();
        TAccessor<PlayerModule> playerAccessor = TAccessor<PlayerModule>.Instance();
        
        edibleAccessor.CreateModules(fruits);
        enemyAccessor.CreateModules(enemies);
        playerAccessor.CreateModules(players);
    }
}
