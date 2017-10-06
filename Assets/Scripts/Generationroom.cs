﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generationroom : MonoBehaviour {
    public string[] rooms;
    float i;
    public float speedup;
	// Use this for initialization
	void Start () {
        Endroom();
        // i = 1;
        i = 1;
	}

    private void FixedUpdate()
    {
        i = i + speedup;
        Statsgame.Setscore(Statsgame.Getscore()+i/10);
        Statsgame.Setspeed(Mathf.Sqrt(i));
    }
    
    public void Endroom() {
       GameObject g= Instantiate(Resources.Load(rooms[Random.RandomRange(0,rooms.Length)]), new Vector3(100, 0, 0), transform.rotation) as GameObject;
    }

}
