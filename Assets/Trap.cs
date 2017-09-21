using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject, 0);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
