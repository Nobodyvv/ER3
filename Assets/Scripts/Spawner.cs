using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //Create a public array of objects to spawn, we will fill this up using the Unity Editor
    public GameObject[] objectsToSpawn;

    float timetoNextSpawn;      //Tracks how long we should wait before spawning a new object 
    float timeSincelastSpawn = 0.0f;  //Tracks the time since we last spawned something

    public float minSpawnTime = 0.5f; //Minimum amount of time between spawning objects
    public float maxSpawnTime = 2.0f;  //Maximum amount of time between spawning objects
   
    void Start()
    {
        //Random.Range returns a random float between two values 
        timetoNextSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }

    void Update()
    {
        //Add Time.deltaTime returns the amount of time passed since the last frame.
        //This will create a float that counts up in seconds
        timeSincelastSpawn = timeSincelastSpawn + Time.deltaTime;

        //If we've counted past the amount of time we need to wait...
        if (timeSincelastSpawn > timetoNextSpawn)
        {
            //Use Random.Range to pick a number between 0 and the amount of items we have on our object list
            int selection = Random.Range(0, objectsToSpawn.Length);

            //Instantiate spawns a GameObject - in this case we tell it to spawn a GameObject from our objectsToSpawn list
            //The second parameter in the brackets tells it where to spawn, so we've entered the postion of the spawner.
            //The third parameter is for rotation, and Quaaternion. idenetity means no rotation
            Instantiate(objectsToSpawn[selection], transform.position, Quaternion.identity);

            //new Vector3 (transform.position.x, Random.Range(transform.position.y-1f, transform.position.y+1f), transform.position.z)

            //After spawning, we select a new random time for the next spawn and set our timer back to zero
            timetoNextSpawn = Random.Range(minSpawnTime, maxSpawnTime);
            timeSincelastSpawn = 0.0f;
        }
    }
}   
        
    

