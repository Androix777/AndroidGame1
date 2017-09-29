using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveroom : MonoBehaviour {
    public GameObject gener;
    bool b=true;
	// Use this for initialization
	void Start () {
        gener = GameObject.FindGameObjectWithTag("Generator");
	}
    private void FixedUpdate()
    {
        if (transform.position.x <=0 & b) { gener.GetComponent<Generationroom>().Endroom(); b = false; }
        if (transform.position.x <= -45f) { Destroy(gameObject, 0); }
        transform.Translate(Vector3.left * Statsgame.Getspeed() * Time.deltaTime);
    }
    
}
