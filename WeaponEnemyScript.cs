using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEnemyScript : MonoBehaviour{

    public float offset;// = offset

    //private float timeBetweenShots;
    //public float startTimeBetweenShots;
    private Vector2 target;
   
    private Transform player;

    private bool facingRight = true;

    public GameObject projectile;
    // Start is called before the first frame update
    void Start(){

        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        
    }

    private void Update() {
        //directia = destinatie - origine
        //fa sa fie pt player targetul
        Vector3 difference = player.position - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        float WorldXPos = player.position.x;

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

    void Flip(){

        facingRight  = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        Scaler.y *= -1;
        transform.localScale = Scaler;
    }
}
