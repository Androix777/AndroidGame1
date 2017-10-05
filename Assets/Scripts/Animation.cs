using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour {
    public float maxrotaion, minrotation,speed,dist,maxscale,minscale;
    public enum anim {rotationtodo,rotation360,Scale , Move }
    public anim type;
    public Vector3[] point;
    Vector3 direction,pos;
    float angle, anglestart;
    int numberpoint;
	// Use this for initialization
	void Start () {
        anglestart = transform.rotation.eulerAngles.z;
        if (type == anim.Move & point.Length>0) {
            direction = Vector3.Normalize(point[0] - transform.localPosition);
            numberpoint = 0; }
        
    }
    
    // Update is called once per frame
    void FixedUpdate() {
 
        switch (type)
        {
            case anim.Move:
               
                if (Vector3.Distance(transform.localPosition, point[numberpoint]) > dist)
                {
                    direction = Vector3.Normalize(point[numberpoint] - transform.localPosition);
                }
                else { if (Vector3.Distance(transform.localPosition, point[numberpoint]) < dist) numberpoint++; }
                if (numberpoint == point.Length) numberpoint = 0;
                transform.localPosition = Vector3.Lerp(transform.localPosition, transform.localPosition + (direction * speed), 1);                  
                break;


            case anim.rotation360:
                transform.rotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z+speed);
                break;

            case anim.rotationtodo:
                if (minrotation <= angle && maxrotaion >= angle) { transform.rotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z + speed); angle += speed; }
                else {if (minrotation <= angle)
                    {
                        transform.localRotation = Quaternion.Euler(0, 0, maxrotaion+ anglestart);
                        angle = maxrotaion;
                    }
                    else {
                        transform.localRotation = Quaternion.Euler(0, 0, minrotation+ anglestart);
                        angle = minrotation;
                    }
                    
                    speed = -speed; }                
                break;

            case anim.Scale:
                if (minscale <= transform.localScale.x && maxscale >= transform.localScale.x) { transform.localScale = new Vector3(transform.localScale.x+ (speed / 100), transform.localScale.y+(speed/100), transform.localScale.z );  }
                else {
                   
                    if (minscale <= transform.localScale.x)
                    {
                        transform.localScale = new Vector3(maxscale, maxscale, transform.localScale.z);
                        
                    }
                    else {
                        transform.localScale = new Vector3(minscale, minscale, transform.localScale.z);

                    }
                    
                    speed = -speed; }
                break;
            
        }	
	}




}
