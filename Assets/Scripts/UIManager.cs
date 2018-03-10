using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public int maxstartspeed;
    public GameObject roomst;
    public bool sound; 

    public int avg,mindif,maxdif;
    public float speed;


	// Use this for initialization
	void Start () {
        if (roomst!=null){if (Statsgame.Getroom()==0){roomst.GetComponent<Text>().text="LOL";}
        else{roomst.GetComponent<Text>().text=Statsgame.Getroom()+"";} 
    }
	}
	
	// Update is called once per frame
	void Update () {
      /*  if (room!=null){
        room.GetComponent<Text>().text=Statsgame.Getroom()+"";}*/

    }
    public void Startgame() {
        Statsgame.Setspeed(speed);
        Statsgame.SetSaveSpeed(speed);
        Statsgame.Setavg(avg);
        Statsgame.Setmindif(mindif);
        Statsgame.Setmaxdif(maxdif);

        SceneManager.LoadScene(1);
       

    }
    public void Restart (){
        Statsgame.Reset();
        SceneManager.LoadScene(1);

    }
     public void MoveToMenu (){
        Statsgame.Reset();
        SceneManager.LoadScene(0);

    }

    public void SetSound(){
        Statsgame.Setsound(sound);
    }


}
