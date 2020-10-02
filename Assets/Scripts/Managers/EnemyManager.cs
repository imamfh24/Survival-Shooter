﻿using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    [SerializeField] MonoBehaviour factory;

    IFactory Factory
    {
        get
        {
            return factory as IFactory;
        }
    }

    void Start ()
    {
        //Mengeksekusi fungsi spawn setiap beberapa detik sesuai dengan nilai SpawnTime
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn ()
    {
        //Jika player telah mati maka tidak membuat enemy baru
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }
        //mendapatkan nilai random
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);
        int spawnEnemy = Random.Range(0, 3);
        //Menduplikasi enemy
        Factory.FactoryMethod(spawnEnemy);

    }
}
