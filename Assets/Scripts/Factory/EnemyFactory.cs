using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour, IFactory
{
    [SerializeField] public GameObject[] enemyPrefab;

    public GameObject FactoryMethod(int tag, Transform enemyPosition)
    {
        GameObject enemy = Instantiate(enemyPrefab[tag], enemyPosition);
        enemy.transform.parent = transform;
        return enemy;
    }
}
