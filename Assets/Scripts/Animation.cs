using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour {
    public float maxrotaion, minrotation,speed,dist;
    public enum anim {rotationtodo,rotation360,Backandforth }
    public anim type;
    public Vector3 first, second;
    Vector3 direction;
    float angle, anglestart;
    bool select;
	// Use this for initialization
	void Start () {
        anglestart = transform.rotation.eulerAngles.z;
        direction = Vector3.Normalize(first - transform.localPosition) ;
        select = true;
        
    }
    
    // Update is called once per frame
    void FixedUpdate() {
 
        switch (type)
        {
            case anim.Backandforth:
               
                if (select & Vector3.Distance(transform.localPosition, first) > dist)
                {
                    direction = Vector3.Normalize(first - transform.localPosition);
                }
                else { if (Vector3.Distance(transform.localPosition, first) < dist) select = false; }

                if (!select & Vector3.Distance(transform.localPosition, second) > dist)
                {
                    direction = Vector3.Normalize(second - transform.localPosition);
                }
                else
                {
                    if (Vector3.Distance(transform.localPosition, second) < dist) select = true;
                }
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
            
        }	
	}




}
