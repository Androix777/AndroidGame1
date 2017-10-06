﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Move : MonoBehaviour {
    public float speed,dist,raySize;
    private int s;
    private Vector3 newPosition,undoposition;
    public GameObject UI,tail;
    private string st;
    GradientAlphaKey[] tails;
    // Use this for initialization
    void Start () {
        newPosition = transform.position;
        Gradient g = tail.GetComponent<LineRenderer>().colorGradient;
        tails = g.alphaKeys;
    }
    private void Update()
    {
        UI.GetComponent<Text>().text =""+ Statsgame.Getscore();
        if (s < Input.touchCount)
        {
            Vector3 touchPosition = new Vector3(Input.GetTouch(Input.touchCount - 1).position.x, Input.GetTouch(Input.touchCount - 1).position.y, 0);
            newPosition = Camera.main.ScreenToWorldPoint(touchPosition);
            newPosition = new Vector3(newPosition.x, newPosition.y, 0);
            undoposition = gameObject.transform.position;
            Backalpha();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 MousePos = Input.mousePosition;
            newPosition = Camera.main.ScreenToWorldPoint(MousePos);
            newPosition = new Vector3(newPosition.x, newPosition.y, 0);
            undoposition = gameObject.transform.position;
            Backalpha();
        }

        RaycastHit2D hit = Physics2D.Raycast(new Vector3(transform.position.x - raySize, transform.position.y - raySize, 0), newPosition - transform.position, Vector3.Distance(transform.position, newPosition));
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y, 0), newPosition - transform.position);
        if (hit.collider != null)
        {
            if (Vector3.Distance(transform.position, hit.transform.position) > dist) { transform.Translate((hit.transform.position - transform.position)); }
            else if (Vector3.Distance(transform.position, hit.transform.position) > 0.001f) { transform.Translate(hit.transform.position - transform.position); }
        }
        else
        {
            transform.position = newPosition;
        }
        s = Input.touchCount;
    }
    // Update is called once per frame
    void FixedUpdate() {        
      


        newPosition=new Vector3(newPosition.x - (1* Statsgame.Getspeed() * Time.deltaTime),newPosition.y,0);
        undoposition= new Vector3(undoposition.x - (1 * Statsgame.Getspeed() * Time.deltaTime), undoposition.y, 0);
        tail.GetComponent<LineRenderer>().SetPosition(1,newPosition);
        tail.GetComponent<LineRenderer>().SetPosition(0, undoposition);
        Newgradtail();

        
    }

    private void OnDestroy()
    {
        Statsgame.Setscore(0);
        SceneManager.LoadScene(0);

    }
    void Newgradtail()
    {
        Gradient g = tail.GetComponent<LineRenderer>().colorGradient;
        GradientAlphaKey[] alh = g.alphaKeys;
        for (int i=0;i<alh.Length;i++) {
            alh[i].alpha = alh[i].alpha - 0.01f;
        }
        g.alphaKeys = alh;       
        tail.GetComponent<LineRenderer>().colorGradient = g;
    }
    void Backalpha() {
        Gradient g = tail.GetComponent<LineRenderer>().colorGradient;
        g.alphaKeys = tails;
        tail.GetComponent<LineRenderer>().colorGradient = g;
    }
}
