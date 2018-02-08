using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generationroom : MonoBehaviour {
    public string[] rooms;
    public float speedroom;
    public float speedup;
    public bool TestMode;
    GameObject Lastrom;
	// Use this for initialization
	void Awake () {
        if (TestMode) {
            // speedroom = Statsgame.Getspeed();
            Statsgame.Setspeed(speedroom);
            Statsgame.SetTestMode(true);
        }
        else { Createroom("Random");
            if (Statsgame.Getspeed() == 1) { Statsgame.Setspeed(speedroom); }
            else { speedroom = Statsgame.Getspeed(); }
            Statsgame.SetTestMode(false);
        }
        
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
    public void Lastroomset(GameObject r) { Lastrom = r; }
    public GameObject Lastroomget() {  return Lastrom; }
}
