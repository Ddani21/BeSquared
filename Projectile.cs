using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour{
    public float speed;
    public float lifeTime;//doar daca vrei sa dureze ceva timp
    public int damage = 10;

    
    public GameObject destroyEffect;

    private void Start(){
        Invoke("DestroyProjectile",lifeTime);
    }

    private void Update(){
        transform.Translate(Vector2.right* speed * Time.deltaTime);

    }

    void DestroyProjectile(){
        Instantiate(destroyEffect,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D (Collider2D hitInfo){
        if ( hitInfo !=null){

            if ( hitInfo.CompareTag("Enemy")){
                hitInfo.GetComponent<Enemy1>().takeDamage(damage);
                ScoreScript.scoreValue +=150;
            }

            if ( hitInfo.CompareTag("FlyingEnemy")){
                hitInfo.GetComponent<FlyingEnemy>().takeDamage(damage);
                ScoreScript.scoreValue +=150;
            }
           
        }
        
        
       
        

        DestroyProjectile();
    }

}




