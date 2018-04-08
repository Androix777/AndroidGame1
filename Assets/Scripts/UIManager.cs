using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;


public class UIManager : MonoBehaviour {
    public int maxstartspeed,difficult;
    public GameObject roomst,roomup ,draw,soundon,soundoff,sound,uidif,uidifdraw,drawscore;
    public GameObject[] background;
    public AudioClip stings;
    public AudioSource stingSource;
    public int mindif,maxdif,uinum=0,x;
    public float speed;

    private void Awake()
    {
        if ((Statsgame.Getmindif() == -1) & (soundon != null))
        {
            Statsgame.Loadstat();
            Statsgame.Loadhighscores();
        }
        if (stings != null)
        {
            if (GameObject.FindGameObjectWithTag("Sound") == null)
            {
                GameObject s = Instantiate(sound) as GameObject;
                stingSource = s.GetComponent<AudioSource>();
                DontDestroyOnLoad(s);
                if (stingSource != null)
                {
                    if (Statsgame.Getsound())
                    {
                        PlaySting();
                    }
                    else
                    {
                        StopSting();
                    }
                }
            }
            else
            {
                GameObject s = GameObject.FindGameObjectWithTag("Sound");
                stingSource = s.GetComponent<AudioSource>();
            }
        }
        Drawrecord();
    }


	// Use this for initialization
	void Start () {
        Drawrecord();
        if (roomst!=null){if (Statsgame.Getroom()==0){roomst.GetComponent<Text>().text="LOL";}
        else{roomst.GetComponent<Text>().text=Statsgame.Getroom()+"";}
        
    }

    if ((soundon!=null) & (soundoff!=null)){

            if (Statsgame.Getsound()){
                soundon.SetActive(true);
                soundoff.SetActive(false);
                
            }else {
                soundoff.SetActive(true);
                soundon.SetActive(false);
            } 
        }
        

}
	
	// Update is called once per frame
	void Update () {
       if (roomup!=null){
        roomup.GetComponent<Text>().text=Statsgame.Getroom()+"";}

        if (draw!=null){Drawbestscore();}

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

    public void SetSound(bool s){
        Statsgame.Setsound(s);
        Statsgame.Savestat();
        if (stingSource!=null){
            if (s){
                PlaySting();
            }else {
                StopSting();
            } 
        }
    }
    public void Drawbestscore(){
        int[] highscore=Statsgame.Gethighscore();
        if (draw!=null){draw.GetComponent<Text>().text=highscore[Statsgame.Getdiffic()]+"";}
    }


void StopSting(){
    
    stingSource.Stop();
}

void PlaySting()
    {  
        stingSource.clip = stings;
        stingSource.Play();
    }

    public void Rightui() {
        if (uinum > 0)
            

        {
            uinum--;
            Setdiffic();
            Drawdiffic();
            Drawbackground();
            Drawrecord();
        }
        
    }
    public void Leftui() {
        if (uinum < 3)
        {
            
            uinum++;
            Setdiffic();
            Drawdiffic();
            Drawbackground();
            Drawrecord();
        }
        
    }
    public void Setdiffic() {
        switch (uinum)
        {
            case 0:
                difficult = 0;
                mindif = 2;
                maxdif = 5;
                speed = 12;
                break;
            case 1:
                difficult = 1;
                mindif = 4;
                maxdif = 7;
                speed = 18;
                break;
            case 2:
                difficult = 2;
                mindif = 5;
                maxdif = 8;
                speed = 24;
                break;
            case 3:
                difficult = 3;
                mindif = 4;
                maxdif = 10;
                speed = 30;
                break;
        }
    }

    public void Drawdiffic()
    {
        string s="";
        switch (uinum)
        {
            case 0:
                s = "Easy";
                break;
            case 1:
                s = "Normal";
                break;
            case 2:
                s = "Hard";
                break;
            case 3:
                s = "Unreal";
                break;
        }

        uidifdraw.GetComponent<Text>().text = s ;
    }

    public void Drawbackground() {
        foreach (GameObject g in background)
        {
            g.SetActive(false);
        }
        background[uinum].SetActive(true);
    }

    private void Drawrecord()
    {
        if (drawscore != null)
        {

        drawscore.GetComponent<Text>().text = Statsgame.Gethighscore()[difficult]+"";        
        
        }
        
    }




}
