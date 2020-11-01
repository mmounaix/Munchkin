﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemySpawner : NetworkBehaviour
{
    // prefab de notre ennemi
    public GameObject enemyPrefab;

    // nombre d'ennemis à faire apparaitre
    public int numberOfEnemies;

    public override void OnStartServer()
    {
        // Apparition du nombre d'ennemis lors du lancement du serveur
        for (int i = 0; i < numberOfEnemies; i++)
        {
            var spawnPosition = new Vector3(
                Random.Range(-8.0f, 8.0f),
                0.0f,
                Random.Range(-8.0f, 8.0f)
            );

            var spawnRotation = Quaternion.Euler(
                0.0f,
                Random.Range(0, 180),
                0.0f
            );

            var enemy = (GameObject)Instantiate(enemyPrefab, spawnPosition, spawnRotation);
            NetworkServer.Spawn(enemy);
        }
    }

}
