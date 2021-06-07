using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour{

    public GameObject[] spawnPoints;
    GameObject currentPoint;
    int index;
    public GameObject[] enemies;
    public float minTimeBetweenSpawns;
    public float maxTimeBetweenSpawns;
    public bool canSpawn ;//daca se poate spawna
    public float spawnTime;// pentru cat timp dureaza timpul de spawn
    public int enemiesOnScreen = 1;//cati inamici sunt
    public GameObject spawnerDoneGameObject;
    public GameObject spawnEffect;

    // Start is called before the first frame update
    void Start(){
        Invoke("SpawnEnemy",0.5f);
    }

    // Update is called once per frame

    
    void SpawnEnemy() {
        
        index = Random.Range(0, spawnPoints.Length);
        currentPoint = spawnPoints[index];
        float timeBetweenSpawns = Random.Range(minTimeBetweenSpawns,maxTimeBetweenSpawns);
        
        Instantiate(enemies[Random.Range(0,enemies.Length)], currentPoint.transform.position,Quaternion.identity);
        enemiesOnScreen++;

        Invoke("SpawnEnemy",timeBetweenSpawns);

       /* if(spawnerDone){
            //done spawning
            spawnerDoneGameObject.SetActive(true);
        }*/
    }
  


}
