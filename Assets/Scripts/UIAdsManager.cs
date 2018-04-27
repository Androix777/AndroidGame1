using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
public class UIAdsManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Statsgame.AddDead();
        Advertisement.Initialize("1780013", false);
        Debug.Log(Statsgame.Getdead());
        if (Statsgame.Getdead() > 5)
        {
            if (Advertisement.IsReady())
            {
                Debug.Log("Load");
                Advertisement.Show();
                Statsgame.Show();
                
            }
        }
        
    }
	
	// Update is called once per frame
	void Update () {

	}
    public void Restart()
    {if (!Advertisement.isShowing)
        {
            Statsgame.Reset();
            SceneManager.LoadScene(1);
        }
    }
    public void MoveToMenu()
    {
        if (!Advertisement.isShowing)
        {
            Statsgame.Reset();
            SceneManager.LoadScene(0);
        }
    }
}
