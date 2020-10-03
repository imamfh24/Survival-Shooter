using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PowerManager : MonoBehaviour
{
    public float range = 10.0f;
    [SerializeField] GameObject[] powerUp;
    [SerializeField] float delaySpawn = 5f;

    private float timerSpawn = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount <= 3)
        {
            TimerSpawnItem();
        }
    }

    private void SpawnPower()
    {
        Vector3 point;
        if (RandomPoint(transform.position, range, out point))
        {
            int indexRandom = Random.Range(0, powerUp.Length);
            GameObject itemSpawn = Instantiate(powerUp[indexRandom], point + new Vector3(0f, 1f), Quaternion.identity);
            itemSpawn.transform.parent = transform;
        }
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        bool condition = true;
        while (condition)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                condition = false;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }

    private void TimerSpawnItem()
    {
        timerSpawn += Time.deltaTime;
        if (timerSpawn > delaySpawn)
        {
            SpawnPower();
            timerSpawn = 0f;
        }
    }
}
