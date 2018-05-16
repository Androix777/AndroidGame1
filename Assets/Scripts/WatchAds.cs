using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class WatchAds : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Advertisement.Initialize("1780013", false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GetMoney() {
        Advertisement.Initialize("1780013", false);
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
        if (Advertisement.isShowing)
        {
            Statsgame.Addmoney(100);
        }
        else { Debug.Log("error"); }
    }

}
