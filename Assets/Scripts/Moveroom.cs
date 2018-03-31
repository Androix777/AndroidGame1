using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveroom : MonoBehaviour {
    public GameObject gener,heros;
    public float speed,speedget;
    bool b=true,hero=true;
    public string nextroom;
	// Use this for initialization
	void Start () {
        heros=GameObject.FindGameObjectWithTag("Hero");
        transform.rotation=Quaternion.Euler(transform.eulerAngles.x,transform.eulerAngles.y,90);

        gener = GameObject.FindGameObjectWithTag("Generator");
        GameObject r = gener.GetComponent<Generationroom>().Lastroomget() ;
       if (r != null)
        {
            transform.position = r.transform.position + new Vector3(0,28, 0);

        }
        gener.GetComponent<Generationroom>().Lastroomset(gameObject);
    }
    private void FixedUpdate()
    {
        if(hero & heros!=null){
            
            if(heros.transform.position.y-transform.position.y-10.5>0){
                Statsgame.Addroom();
                hero=false;
            }
        }
        if (!Statsgame.GetTestMode())
        {
            if (transform.position.y <= 25 & b) { gener.GetComponent<Generationroom>().Createroom(nextroom); b = false; }
        if (transform.position.y <= -60f) { Destroy(gameObject, 0); }            
        transform.Translate(Vector3.down * Statsgame.Getspeed() * Time.deltaTime,Space.World); }
    }
    
}
