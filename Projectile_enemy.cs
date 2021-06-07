using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float lifeTime;//doar daca vrei sa dureze ceva timp
    public int damage;


    public GameObject destroyEffect;

    private void Start(){
        Invoke("DestroyProjectile",lifeTime);
    }

    private void Update(){
        transform.Translate(Vector2.right* speed * Time.deltaTime);
    }

    void DestroyProjectile(){

        Destroy(gameObject);
    }

    void OnTriggerEnter2D (Collider2D hitInfo){
            if ( hitInfo.CompareTag("Player")){
                hitInfo.GetComponent<Player_controller>().takeDamage(damage);
            }
        Destroy(gameObject);
    }
}
