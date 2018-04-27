using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.Advertisements;

public class MoveHero : MonoBehaviour {
    public float speed,dist,second;
    private int s;
    private Vector3 newPosition,undoposition;
    public GameObject UI,uimeny,tail,explosion,soundDead;
    private string st;
    bool blocked = true,move=false;
    RaycastHit2D hit;
    bool dead;
    void Start () {
        Advertisement.Initialize("1780013", false);
        newPosition = transform.position;
        GameObject g = Instantiate(Resources.Load("Heros/" + Statsgame.Gethero()),transform.position,transform.rotation) as GameObject;
        g.transform.SetParent(gameObject.transform);
        tail=g.transform.GetChild(0).gameObject;
        explosion = g.transform.GetChild(1).gameObject; 
        DOTween.Init();
    }
    private void Update()
    {
        
    
        if (UI != null) { UI.GetComponent<Text>().text = "" + Statsgame.Getscore(); }
        if (s < Input.touchCount & blocked)
        {        
            Vector3 touchPosition = new Vector3(Input.GetTouch(Input.touchCount - 1).position.x , Input.GetTouch(Input.touchCount - 1).position.y, 0);
            newPosition = Camera.main.ScreenToWorldPoint(touchPosition);
            newPosition = new Vector3(newPosition.x, newPosition.y, 0);
            undoposition = gameObject.transform.position;
            move=true;
           
        }
        if (Input.GetKeyDown(KeyCode.Mouse0)& blocked)
        {
            Vector3 MousePos = Input.mousePosition;
            newPosition = Camera.main.ScreenToWorldPoint(MousePos);
            newPosition = new Vector3(newPosition.x, newPosition.y, 0);
            undoposition = gameObject.transform.position;
            move=true;
            

        }
        if (blocked) {
            hit = Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y, 0), newPosition - transform.position, Vector3.Distance(transform.position, newPosition));
            Debug.DrawRay(new Vector3(transform.position.x, transform.position.y, 0), newPosition - transform.position);
        }
         if (hit.collider != null || !blocked)
         {
            GameObject g = GameObject.FindGameObjectWithTag("Generator");
            g.GetComponent<Generationroom>().StopAll();          
            newPosition = hit.point;
            transform.position = newPosition;
            //transform.DOLocalMove(newPosition,300/second).SetSpeedBased().SetEase(Ease.Linear);           
            blocked = false;
        }
         else
         {
            transform.position = newPosition;
            //transform.DOLocalMove(newPosition, 300).SetSpeedBased().SetEase(Ease.Linear);
            if (move)
            {
                GameObject t=Instantiate(tail,undoposition,transform.rotation);
                t.GetComponent<Tail>().setTail(undoposition,newPosition);
                t.SetActive(true);
                s = Input.touchCount;
                move=false;
            }
        }
       
    }
    // Update is called once per frame
    void FixedUpdate() {
       

        newPosition=new Vector3(newPosition.x ,newPosition.y- (1* Statsgame.Getspeed() * Time.deltaTime),0);
        undoposition= new Vector3(undoposition.x , undoposition.y- (1 * Statsgame.Getspeed() * Time.deltaTime), 0);
       
    }

    private void OnDestroy()
    {
        if (Statsgame.Getdead() > 5)
        {
            if (Advertisement.IsReady())
            {
                Advertisement.Show();
                Statsgame.Show();
            }
        }
        
        //Statsgame.Setscore(0);
        Statsgame.Addscore();
        //Statsgame.Moneypostgame();
        Statsgame.Savehighscores();
        Statsgame.Savestat();
        uimeny.SetActive(true);
       // if (Statsgame.interstitial.IsLoaded()) { Statsgame.interstitial.Show(); Debug.Log("Show"); }
            
        
    }
  public void kill() {
        if (Statsgame.Getsound()) { Instantiate(soundDead); }
        GameObject exp= Instantiate(explosion,transform.position,transform.rotation);
        exp.SetActive(true);
        GameObject g = GameObject.FindGameObjectWithTag("Generator");
        g.GetComponent<Generationroom>().StopAll();    
    }
}
