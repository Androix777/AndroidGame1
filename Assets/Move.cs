using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour {
    public float speed,dist,gravity;
    private int s;
    private Vector3 newPosition;
    public GameObject UI;
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


        if (Vector3.Distance(transform.position, newPosition) > dist) { transform.Translate(Vector3.Normalize((newPosition - transform.position)) * speed); }
        else if (Vector3.Distance(transform.position, newPosition) > 0.001f) { transform.Translate(newPosition - transform.position); }

        UI.GetComponent<Text>().text=" "+transform.position.x+ " " + transform.position.y+" " + transform.position.z+" "+s;

        s = Input.touchCount;
        newPosition=new Vector3(newPosition.x - (1* Statsgame.speed * Time.deltaTime),newPosition.y,0);


    }
}
