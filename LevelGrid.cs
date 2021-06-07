using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour {
   
    public GameObject enemy;
    float randX;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;//2secunde
    float nextSpawn = 0.0f;

    public GameObject[] spawnLocations;
    public GameObject player;

    private Vector2 respawnLocation;

    // Update is called once per frame
    void Awake(){

        spawnLocations = GameObject.FindGameObjectsWithTag("SpawnPoint");
   
    }

    void Start(){

        //player = (GameObject)Resources.Load("Player2",typeof(GameObject));

       // respawnLocation = new Vector2(player.transform.position.x,player.transform.position.y);
        
        //SpawnPlayer();
    }
    void update(){

        /*if (Time.time >nextSpawn){
            nextSpawn = Time.time+spawnRate;
            randX = Random.Range(-8.4f,8.4f);
            whereToSpawn = new Vector2(randX,transform.position.y);
            Instantiate(enemy,whereToSpawn,Quaternion.identity);
        }

        */
    }

    private void SpawnPlayer(){

        //int spawn = Random.Range(0,spawnLocations.Length);

        //Instantiate(player, spawnLocations[spawn], Quaternion.identity);

    }
}
