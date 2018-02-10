﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveroom : MonoBehaviour {
    public GameObject gener;
    public float speed,speedget;
    bool b=true;
    public string nextroom;
	// Use this for initialization
	void Start () {

        gener = GameObject.FindGameObjectWithTag("Generator");
        GameObject r = gener.GetComponent<Generationroom>().Lastroomget() ;
       if (r != null)
        {
            transform.position = r.transform.position + new Vector3(28,0, 0);

        }
        gener.GetComponent<Generationroom>().Lastroomset(gameObject);
    }
    private void FixedUpdate()
    {
        if (!Statsgame.GetTestMode())
        {
            if (transform.position.x <= 25 & b) { gener.GetComponent<Generationroom>().Createroom(nextroom); b = false; }
        if (transform.position.x <= -60f) { Destroy(gameObject, 0); }      
        speedget = Statsgame.Getspeed();
        speed = Vector3.left.x * Statsgame.Getspeed() * Time.deltaTime;
        transform.Translate(Vector3.left * Statsgame.Getspeed() * Time.deltaTime,Space.World); }
    }
    
}
