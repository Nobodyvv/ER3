using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //Create a public array of objects to spawn, we will fill this up using the Unity Editor
    public GameObject[] objectsToSpawn;

    float distancetoNextSpawn;      //Tracks how long we should wait before spawning a new object 
    float distanceSincelastSpawn = 0.0f;  //Tracks the distance since we last spawned something

    public float minSpawnDistance = 0.5f; //Minimum amount of distance between spawning objects
    public float maxSpawnDistance = 2.0f;  //Maximum amount of distance between spawning objects
    float distanceOfLastSpawn;
   
    void Start()
    {
        //Random.Range returns a random float between two values 
        distancetoNextSpawn = Random.Range(minSpawnDistance, maxSpawnDistance);
        distanceOfLastSpawn = transform.position.x;
}

    void Update()
    {
      
        distanceSincelastSpawn = transform.position.x - distanceOfLastSpawn;


        if (distanceSincelastSpawn > distancetoNextSpawn)
        {
      
            int selection = Random.Range(0, objectsToSpawn.Length);

         
            Instantiate(objectsToSpawn[selection], transform.position, Quaternion.identity);

        
            distancetoNextSpawn = Random.Range(minSpawnDistance, maxSpawnDistance);
            distanceSincelastSpawn = 0.0f;
            distanceOfLastSpawn = transform.position.x;
        }
    }
}   
        
    

