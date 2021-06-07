using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour{
    public int health = 100;
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float shootingDistance;

    private bool shoot;
    private bool facingRight = true;
    private float timeBetweenShots;
    public float startTimeBetweenShots;//diferenta intre gloante

    public int startHowManyShots;//cate gloante sa traga intr-un burst
    private int howManyShots;

    public float startTimeBurst;//cat de mari sa fie bursturile
    private float timeBetweenBursts;


    private Transform player;
    public Transform shotPoint;
    public GameObject projectile;
    public GameObject deathEffect;

    private EnemySpawner enemySpawning;
    
    public void takeDamage(int damage){

        health -=damage;
        


    }



    void Start(){

        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        timeBetweenShots = startTimeBetweenShots;
        timeBetweenBursts = startTimeBurst;
        howManyShots = startHowManyShots;
    }

    // Update is called once per frame
    void Update(){
        
        if(health <= 0 ){
            
            Destroy(gameObject);
            Instantiate(deathEffect,transform.position,Quaternion.identity);
           
        }

        float WorldXPos = player.position.x;
        if(Vector2.Distance(transform.position, player.position) >  stoppingDistance){
            // inmultim cu Time.deltaTime ca  pc-urile mai rapide sa nu faca caracterele sa se miste mai rapid decat trebuie; 
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime); 

        } else if ( Vector2.Distance(transform.position, player.position) <  stoppingDistance &&  Vector2.Distance(transform.position, player.position) > retreatDistance ) {
            // sta pe loc
            transform.position = this.transform.position;
        

        } else if(Vector2.Distance(transform.position, player.position) < retreatDistance){
            // daca e mai aproape decat trebuie atunci se va indeparta(a.k.a player-ul se apropie);
            transform.position = Vector2.MoveTowards(transform.position,player.position, -speed * Time.deltaTime);

        }
                


        if (timeBetweenBursts <= 0 ){

            if ( timeBetweenShots <= 0 ){

                if ( getDistance() ){//click stanga
                    FindObjectOfType<audioManager>().Play("Shoot");
                    Instantiate(projectile, shotPoint.position, shotPoint.transform.rotation);
                    
                

                    timeBetweenShots = startTimeBetweenShots;
                    howManyShots--;

                    if(howManyShots == 0){

                        timeBetweenBursts = startTimeBurst;
                        howManyShots = startHowManyShots;

                    }
                }
            }else{
            
                timeBetweenShots -= Time.deltaTime;

            }
            
        }else{

            timeBetweenBursts -= Time.deltaTime;

        }    
        if(WorldXPos > transform.position.x){ 
            if (facingRight == false ) { 
        
                Flip();
                
            }
        } else {
            if ( facingRight == true ){

                Flip();
                
            }
        }



    }

    bool getDistance(){
        if (Vector2.Distance(transform.position, player.position) <= shootingDistance){
           return true;

        }else {
            return false;
        }
    }


    void Flip(){

        facingRight  = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }




}
