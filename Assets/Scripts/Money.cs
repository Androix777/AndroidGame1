using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour {
    public int money;
	// Use this for initialization
	void Start () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hero") { Statsgame.Setmoney(Statsgame.Getmoney()+money);  Destroy(gameObject, 0);  };
    }
    // Update is called once per frame
    void Update () {
		
	}
}
