using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hero") { collision.GetComponent<MoveHero>().kill(); collision.gameObject.SetActive(false); Destroy(collision.gameObject,1); };
    }
    // Update is called once per frame
    void Update () {
		
	}
}
