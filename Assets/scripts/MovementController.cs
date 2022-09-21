using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    float gekozenSnelheid;
    [SerializeField]
    float luchtSnelheid;

    float snelheid;

    [SerializeField]
    float jumpHeight;
    bool canJump = true;

    float zSpeed=0;
    float xSpeed=0;
    Vector3 moveVector;

    // Collision prevCol;


    // Start is called before the first frame update
    void Start()
    {
        snelheid=gekozenSnelheid;
    }

    // Update is called once every frame, for all code except physics & movement
    void Update()
    {

        //springen input check moet elk frame, als je het anders te kort indrukt gebeurt er niks, zo wel
        if(Input.GetKey(KeyCode.Space)) {
                if(canJump==true){
                    GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
                    canJump=false;
                }
        }
        
    }
    //FixedUpdate is called every x interval, for physics calculations, movement, etc.
    void FixedUpdate(){
        if(!canJump){
            snelheid=luchtSnelheid;
        }else{
            snelheid=gekozenSnelheid;
        }

        if(Input.GetKey(KeyCode.W)){
            zSpeed=1;
        }
        if(Input.GetKey(KeyCode.S)) {
            zSpeed=-1;
        }
        if(Input.GetKey(KeyCode.A)) {
            xSpeed=-1;
        }
        if(Input.GetKey(KeyCode.D)) {
            xSpeed=1;
        }
        Vector3 moveVector = new Vector3(xSpeed, 0, zSpeed);
        moveVector.Normalize();
        GetComponent<Rigidbody>().AddForce(moveVector*snelheid, ForceMode.VelocityChange);
        xSpeed = 0;
        zSpeed = 0;

    }
    void OnCollisionEnter(Collision col){
        if(col.gameObject.tag!="unjumpable"){
            canJump=true;
        }
        // prevCol=col;
        
    }
    //void OnCollisionExit(Collision col){
        // if(col==prevCol){
        //     canJump=false;
        // }else{canJump=true;}
    //}
    
}
