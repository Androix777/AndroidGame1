using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public int maxstartspeed;
    public GameObject write;

    public int avg,mindif,maxdif;
    public float speed;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (write!=null){
        write.GetComponent<Text>().text=(int)(gameObject.GetComponent<Slider>().value * maxstartspeed)+" ";}

    }
    public void Startgame() {
        Statsgame.Setspeed(speed);
        Statsgame.SetSaveSpeed(speed);
        Statsgame.Setavg(avg);
        Statsgame.Setmindif(mindif);
        Statsgame.Setmaxdif(maxdif);





        //Statsgame.Setspeed (gameObject.GetComponent<Slider>().value * maxstartspeed);
        //Statsgame.SetSaveSpeed (gameObject.GetComponent<Slider>().value * maxstartspeed);

       // Statsgame.Setavg(gameObject.GetComponent<Slider>().value * maxstartspeed);
       // Statsgame.Setmindif(gameObject.GetComponent<Slider>().value * maxstartspeed);
       // Statsgame.Setmindif(gameObject.GetComponent<Slider>().value * maxstartspeed);

        SceneManager.LoadScene(1);
       

    }
    public void Restart (){
        Statsgame.ResetSpeed();
        SceneManager.LoadScene(1);

    }
     public void MoveToMenu (){
        
        SceneManager.LoadScene(0);

    }

}
