using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour {
    public float speed,dist,raySize;
    private int s;
    private Vector3 newPosition;
    public GameObject UI;
    private string st;
    // Use this for initialization
    void Start () {
        newPosition = transform.position;

    }
    
    // Update is called once per frame
    void FixedUpdate() {

       if (s< Input.touchCount) {
            Vector3 touchPosition = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0);
            newPosition = Camera.main.ScreenToWorldPoint(touchPosition);
            newPosition = new Vector3(newPosition.x, newPosition.y,0);
        }


        RaycastHit2D hit = Physics2D.Raycast(new Vector3(transform.position.x - raySize, transform.position.y - raySize, 0), newPosition - transform.position);
        Debug.DrawRay(new Vector3(transform.position.x - raySize, transform.position.y - raySize, 0), newPosition - transform.position);
        if (hit.collider != null )
        {       
            if (Vector3.Distance(transform.position, newPosition) > dist) { transform.Translate(Vector3.Normalize((newPosition - transform.position)) * speed); }
            else if (Vector3.Distance(transform.position, newPosition) > 0.001f) { transform.Translate(newPosition - transform.position); }
        }
        else
        {
            transform.position = newPosition;
        }
        UI.GetComponent<Text>().text=" "+transform.position.x+ " " + transform.position.y+" " + transform.position.z+" "+s+"  "+st;

        s = Input.touchCount;
        newPosition=new Vector3(newPosition.x - (1* Statsgame.Getspeed() * Time.deltaTime),newPosition.y,0);


    }
}
