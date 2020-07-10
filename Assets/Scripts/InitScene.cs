using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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

        if (randomFruits)
        {
            List<GameObject> newFruits = new List<GameObject>();
            int nbFruits = Random.Range(5, 15);
            for (int i = 0; i < nbFruits; i++)
            {
                newFruits.Add(Instantiate(fruitPrefab));
                newFruits[i].transform.position = new Vector3(Random.Range(-7.5f, 7.5f), -1.6f, Random.Range(-7.5f, 7.5f));
            }
            edibleAccessor.CreateModules(newFruits);
        }

        if (randomPlayers)
        {
            List<GameObject> newPlayers = new List<GameObject>();
            int nbPlayers = Random.Range(1, 4);
            for (int i = 0; i < nbPlayers; i++)
            {
                newPlayers.Add(Instantiate(playerPrefab));
                newPlayers[i].transform.position = new Vector3(Random.Range(-7f, 7f), -1.4f, Random.Range(-7f, 7f));
            }
            playerAccessor.CreateModules(newPlayers);
        }

        if (randomEnemies)
        {
            List<GameObject> newEnemies = new List<GameObject>();
            int nbEnemies = Random.Range(1, 4);
            for (int i = 0; i < nbEnemies; i++)
            {
                newEnemies.Add(Instantiate(enemyPrefab));
                newEnemies[i].transform.position = new Vector3(Random.Range(-7f, 7f), -1.4f, Random.Range(-7f, 7f));
            }
            enemyAccessor.CreateModules(newEnemies);
        }
    }
}
