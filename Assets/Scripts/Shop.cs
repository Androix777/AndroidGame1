using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {
	int num,cost;
	enum stat
	{
		open=0,close=1,use=2
	}
	stat stasbutton;
	// Use this for initialization
	void Start () {
		if (Statsgame.GetSkin(num)){
		stasbutton=stat.open;
		if (Statsgame.Getnumhero()==num){
		stasbutton=stat.use;
		}
		}else {
			stasbutton=stat.close;
		}
		
		
		
		
	}
	private void Update() {
	if (stasbutton==stat.use & Statsgame.Getnumhero()!=num){
		stasbutton=stat.open;
	}	
	}
	public void PressButton(){

		switch (stasbutton)
        {
            case stat.open:
                stasbutton=stat.use;
				Statsgame.Sethero(num);
                break;
			case stat.close:
				if (Statsgame.Getmoney()>=cost){
				stasbutton=stat.open;
				Statsgame.Setmoney(Statsgame.Getmoney()-cost);
				Statsgame.Addskin(num);
				}
				break;
		}
	}
}
