using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBack : MonoBehaviour {
    public GameObject market, info;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (market != null)
            {
                if (market.active) market.SetActive(false);
                else
                {
                    if (info != null)
                    {
                        if (info.active) info.SetActive(false);
                        else { Application.Quit(); }
                    }
                    else { Application.Quit(); }
                }
            }
            else
            {
                if (info != null)
                {
                    if (info.active) info.SetActive(false);
                    else { Application.Quit(); }
                }
                else { Application.Quit(); }
            }
        }
    }

    


}
