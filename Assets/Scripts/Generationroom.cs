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
        speedroom = Statsgame.Getspeed();
        Createroom("Random");
        // i = 1;
        
	}

    private void FixedUpdate()
    {
		speedroom = speedroom + speedup;
		Statsgame.Setscore(Statsgame.Getscore()+speedroom/10);
		Statsgame.Setspeed(speedroom);
    }
    
    
    public void Createroom(string room)
    {if (room != "Random") {
            Instantiate(Resources.Load(room), new Vector3(45, 0, 0), transform.rotation); }
        else
        {
            if (rooms.Length > 0)
            {
                Instantiate(Resources.Load(rooms[Random.Range(0, rooms.Length)]), new Vector3(45, 0, 0), transform.rotation);  }
        }
    }
}
