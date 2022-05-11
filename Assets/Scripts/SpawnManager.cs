using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    [SerializeField] private float spawnRate = 5f;
    [SerializeField] private Transform[] spawnPosition;
    private TimeManager timeManager;
    
    private float nextSpawnTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        timeManager = FindObjectOfType<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > nextSpawnTime && timeManager.gameOver == false && timeManager.gameFinished == false)
        {
            nextSpawnTime += spawnRate;
            SpawnObject(objects[RandomObjectNumber()], spawnPosition[RandomSpawnNumber()]);
        }
        
    }

    private void SpawnObject(GameObject objectToSpawn,Transform newTransform)
    {
        Instantiate(objectToSpawn, newTransform.position,newTransform.rotation);
    }

    private int RandomSpawnNumber()
    {
        return Random.Range(0,spawnPosition.Length);
    }

    private int RandomObjectNumber()
    {
        return Random.Range(0,objects.Length);
    }
   
}
