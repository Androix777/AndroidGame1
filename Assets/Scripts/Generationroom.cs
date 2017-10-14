using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generationroom : MonoBehaviour {
    public string[] rooms;
    public float speedroom;
    public float speedup;

	// Use this for initialization
	void Start () {
        Endroom();
        // i = 1;
        
	}

    private void FixedUpdate()
    {
		speedroom = speedroom + speedup;
		Statsgame.Setscore(Statsgame.Getscore()+speedroom/10);
		Statsgame.Setspeed(Mathf.Sqrt(speedroom));
    }
    
    public void Endroom() {
        if (rooms.Length>0) { GameObject g = Instantiate(Resources.Load(rooms[Random.RandomRange(0, rooms.Length)]), new Vector3(100, 0, 0), transform.rotation) as GameObject; }
    }

}
