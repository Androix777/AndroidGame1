using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class Statsgame  {
    //static List <int> Highscores;
    static int maxscorehard=0,maxscroreeasy=0,maxscorenormal=0,maxscoreunreal=0,diffic;
    private static float speed=0f,score,money,saveSpeed;
    private static int maxdif=-1,mindif=-1,room=0;
    static bool TestMode,Sound;

    public static void SetTestMode (bool TestMod){ TestMode = TestMod; }
    public static bool GetTestMode() { return TestMode; }
    public static float Getmoney() { return money; }
    public static void Setmoney(float s) { money = s; }

    public static float Getspeed() { return speed; }
    public static void Setspeed(float s) { speed = s;}

    public static float Getscore() { return score; }
    public static void Setscore(float s) { score = s; }


     public static int Getmindif() { return mindif; }
    public static void Setmindif(float s) { mindif = (int)s; }
     
     public static int Getmaxdif() { return maxdif; }
    public static void Setmaxdif(float s) { maxdif = (int)s; }

    public static void Reset(){
        room=0;
        speed=saveSpeed;
        
    }
    public static void SetSaveSpeed(float s){
        saveSpeed=s;    
    }

    public static void Setsound(bool s){
        Sound=s;

    }
    public static bool Getsound(){
        return Sound;

    }
    public static void Setroom(int s){
        room=s;

    }
    public static int Getroom(){
        return room;

    }
     public static void Addroom(){
        room++;

    }

    public static void Savehighscores(){
        
        string[] str=new string[4];    
        str[0]=maxscroreeasy.ToString();
        str[1]=maxscorenormal.ToString();
        str[2]=maxscorehard.ToString();
        str[3]=maxscoreunreal.ToString();    

        File.WriteAllLines(Application.persistentDataPath+"/score.sc",str);
    }
    public static void Loadhighscores(){
        
        string[] str=new string[4];     
        if (File.Exists(Application.persistentDataPath+"/score.sc"))  {
        str=File.ReadAllLines(Application.persistentDataPath+"/score.sc");
        maxscroreeasy=int.Parse(str[0]);
        maxscorenormal=int.Parse(str[1]);
        maxscorehard=int.Parse(str[2]);
        maxscoreunreal=int.Parse(str[3]);

        }
    }

    public static int[] Gethighscore(){
        int[] ret=new int[4];
        ret[0]=maxscroreeasy;
        ret[1]=maxscorenormal;
        ret[2]=maxscorehard;
        ret[3]=maxscoreunreal;

        return ret;
    }

    public static void Addscore(){
        if (diffic==0 & maxscroreeasy<room){maxscroreeasy=room;}
        if (diffic==1 & maxscorenormal<room){maxscorenormal=room;}
        if (diffic==2 & maxscorehard<room){maxscorehard=room;}
        if (diffic==3 & maxscoreunreal<room){maxscoreunreal=room;}
        
    }

    public static void Setdiffic(int d){
        diffic=d;
    }






}
