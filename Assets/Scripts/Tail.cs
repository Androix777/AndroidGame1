using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour {
    Vector3 pos;
    bool t;
    public float dist,speed;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (t) {
            if (Vector3.Distance(pos, transform.position) > dist) { transform.Translate(Vector3.Normalize(pos - transform.position) * speed); }
            else { transform.position = pos; } };
	}
    public void begin(Vector3 newpos) { pos = newpos;t = true; }
}
