using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Statsgame  {
    private static float speed=3f,score,money;


    public static float Getmoney() { return money; }
    public static void Setmoney(float s) { money = s; }

    public static float Getspeed() { return speed; }
    public static void Setspeed(float s) { speed = s; }

    public static float Getscore() { return score; }
    public static void Setscore(float s) { score = s; }
}
