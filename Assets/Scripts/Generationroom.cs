using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generationroom : MonoBehaviour {
    public string[] rooms;
	// Use this for initialization
	void Start () {
        Endroom();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //7.2 0 5.4
    public void Endroom() {
       GameObject g= Instantiate(Resources.Load(rooms[Random.RandomRange(0,rooms.Length)]), new Vector3(90, 0, 0), transform.rotation) as GameObject;
    }

}
