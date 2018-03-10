using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Statsgame  {
    private static float speed=0f,score,money,saveSpeed;
    private static int avg=-1,maxdif=-1,mindif=-1,room=0;
    static bool TestMode,Sound;

    public static void SetTestMode (bool TestMod){ TestMode = TestMod; }
    public static bool GetTestMode() { return TestMode; }
    public static float Getmoney() { return money; }
    public static void Setmoney(float s) { money = s; }

    public static float Getspeed() { return speed; }
    public static void Setspeed(float s) { speed = s; }

    public static float Getscore() { return score; }
    public static void Setscore(float s) { score = s; }


     public static int Getmindif() { return mindif; }
    public static void Setmindif(float s) { mindif = (int)s; }
     
     public static int Getmaxdif() { return maxdif; }
    public static void Setmaxdif(float s) { maxdif = (int)s; }
     
     public static int Getavg() { return avg; }
    public static void Setavg(float s) { avg = (int)s; }

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





}
