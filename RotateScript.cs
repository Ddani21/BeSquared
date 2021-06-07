using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform rotationCenter;

    public float rotationRadius;
    public float angularSpeed;

    float posX,posY,angle;
    void Start () {
        angle = 0;
    } 
    // Update is called once per frame
    void Update(){
        
        posX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
        posY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius;
        transform.position = new Vector2 (posX, posY);
        angle = angle + Time.deltaTime * angularSpeed;

        if ( angle >=360f) angle = 0f;


    }

}
