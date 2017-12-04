using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {
    public int maxstartspeed;
    public GameObject write;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        write.GetComponent<Text>().text=gameObject.GetComponent<Slider>().value * maxstartspeed+" ";

    }
    public void Startgame() {
        Statsgame.Setspeed (gameObject.GetComponent<Slider>().value * maxstartspeed);
        SceneManager.LoadScene(1);
       

    }
}
