using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {
	public int num,cost;
	public enum stat
	{
        
		open=0,close=1,use=2
	}
	public stat stasbutton;
	// Use this for initialization
	void Start () {
       
		if (Statsgame.GetSkin(num)){
        gameObject.GetComponent<Image>().color = new Color(255, 255, 255);
        stasbutton =stat.open;
		if (Statsgame.Gethero()==num){
		stasbutton=stat.use;
                Statsgame.Sethero(num);
                gameObject.GetComponent<Image>().color = new Color(0, 255, 0);
            }
		}else
        {
            gameObject.GetComponent<Image>().color = new Color(255, 0, 0);
            stasbutton =stat.close;
	    }
		
		
		
		
	}
	private void Update() {
	if (stasbutton==stat.use & Statsgame.Gethero()!=num){
		stasbutton=stat.open;
        gameObject.GetComponent<Image>().color = new Color(255, 255, 255);
        }	
	}
	public void PressButton(){

		switch (stasbutton)
        {
            case stat.open:
                stasbutton=stat.use;
				Statsgame.Sethero(num);
                gameObject.GetComponent<Image>().color = new Color(0,255,0); 
                break;
			case stat.close:
				if (Statsgame.Getmoney()>=cost){
                gameObject.GetComponent<Image>().color = new Color(255, 255, 255);
                stasbutton =stat.open;
				Statsgame.Setmoney(Statsgame.Getmoney()-cost);
				Statsgame.Addskin(num);
				}
				break;
		}
	}
}
