using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class MoveHero : MonoBehaviour {
    public float speed,dist,second;
    private int s;
    private Vector3 newPosition,undoposition;
    public GameObject UI,uimeny,tail,explosion;
    private string st;
    bool blocked = true,move=false;
    RaycastHit2D hit;
    bool dead;
    void Start () {
        newPosition = transform.position;
        //Gradient g = tail.GetComponent<LineRenderer>().colorGradient;  
        DOTween.Init();
    }
    private void Update()
    {
        
    
        if (UI != null) { UI.GetComponent<Text>().text = "" + Statsgame.Getscore(); }
        if (s < Input.touchCount & blocked)
        {
            Input.
            Vector3 touchPosition = new Vector3(Input.GetTouch(Input.touchCount - 1).position.x, Input.GetTouch(Input.touchCount - 1).position.y, 0);
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
            transform.DOLocalMove(newPosition,300/second).SetSpeedBased().SetEase(Ease.Linear);           
            blocked = false;
        }
         else
         {
            transform.DOLocalMove(newPosition, 300).SetSpeedBased().SetEase(Ease.Linear);
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
       

        newPosition=new Vector3(newPosition.x - (1* Statsgame.Getspeed() * Time.deltaTime),newPosition.y,0);
        undoposition= new Vector3(undoposition.x - (1 * Statsgame.Getspeed() * Time.deltaTime), undoposition.y, 0);
       
    }

    private void OnDestroy()
    {
        
        Statsgame.Setscore(0);
        uimeny.SetActive(true);//!

    }
  public void kill() {
        Instantiate(explosion,transform.position,transform.rotation);
        GameObject g = GameObject.FindGameObjectWithTag("Generator");
        g.GetComponent<Generationroom>().StopAll();    
    }
}
