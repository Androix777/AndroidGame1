using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public int maxstartspeed,difficult;
    public GameObject roomst,roomup ,draweasy,drawnormal,drawhard,drawunreal;
    public bool sound; 

    public int mindif,maxdif;
    public float speed;


	// Use this for initialization
	void Start () {
        Statsgame.Loadhighscores();
        if (roomst!=null){if (Statsgame.Getroom()==0){roomst.GetComponent<Text>().text="LOL";}
        else{roomst.GetComponent<Text>().text=Statsgame.Getroom()+"";} 
    }
	}
	
	// Update is called once per frame
	void Update () {
       if (roomup!=null){
        roomup.GetComponent<Text>().text=Statsgame.Getroom()+"";}

    }
    public void Startgame() {
        Statsgame.Setdiffic(difficult);
        Statsgame.Setspeed(speed);
        Statsgame.SetSaveSpeed(speed);
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

    public void Drawscore(){
        int[] highscore=Statsgame.Gethighscore();
        if (draweasy!=null){draweasy.GetComponent<Text>().text=highscore[0]+"";}
        if (drawnormal!=null){drawnormal.GetComponent<Text>().text=highscore[1]+"";}
        if (drawhard!=null){drawhard.GetComponent<Text>().text=highscore[2]+"";}
        if (drawunreal!=null){drawunreal.GetComponent<Text>().text=highscore[3]+"";}

    }


}
