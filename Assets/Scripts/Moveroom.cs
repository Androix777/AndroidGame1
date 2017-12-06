using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveroom : MonoBehaviour {
    public GameObject gener;
    bool b=true;
    public string nextroom;
	// Use this for initialization
	void Start () {
        gener = GameObject.FindGameObjectWithTag("Generator");
        GameObject r = gener.GetComponent<Generationroom>().Lastroomget() ;
      if (r != null)
        {
            transform.position = r.transform.position + new Vector3(20,0, 0);
        }
        gener.GetComponent<Generationroom>().Lastroomset(gameObject);
    }
    private void FixedUpdate()
    {
        if (transform.position.x <=25 & b) { gener.GetComponent<Generationroom>().Createroom(nextroom); b = false; }
        if (transform.position.x <= -60f) { Destroy(gameObject, 0); }
        transform.Translate(Vector3.left * Statsgame.Getspeed() * Time.deltaTime);
    }
    
}
