using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveroom : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    private void FixedUpdate()
    {
        if (transform.position.x < -3.3f) { transform.position = Vector3.right * 3.3f; }
        transform.Translate(Vector3.left * Statsgame.speed * Time.deltaTime);
    }
    
}
