using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour{
    // Start is called before the first frame update
    public float offset;// = offset

    public GameObject projectile;
    public Transform shotPoint;//punctul de un se spawneaza bullet-ul


    public Transform weaponRotation;
    private float timeBetweenShots;
    public float startTimeBetweenShots;
    private bool facingRight = true;

    void start(){
        timeBetweenShots = startTimeBetweenShots;

    }


    private void Update() {
        //directia = destinatie - origine
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        float WorldXPos = Camera.main.ScreenToWorldPoint(pos).x;

        if(WorldXPos > transform.position.x){ // character it's your char game objectx
            if (facingRight == false ) { 
        
                Flip();
                
            }
        } else {
            if ( facingRight == true ){

                Flip();
                
            }
        }
        
        if ( timeBetweenShots <= 0){
            
            if ( Input.GetMouseButtonDown(0)){//click stanga
                FindObjectOfType<audioManager>().Play("Shoot");
                Instantiate(projectile, shotPoint.position, transform.rotation);
               
            }
        }
        else{

            timeBetweenShots -= Time.deltaTime;

        }



    }
     void Flip(){

        facingRight  = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.y *= -1;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
   
}
