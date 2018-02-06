using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Statsgame  {
    private static float speed=1f,score,money;
    static bool TestMode;

    public static void SetTestMode (bool TestMod){ TestMode = TestMod; }
    public static bool GetTestMode() { return TestMode; }
    public static float Getmoney() { return money; }
    public static void Setmoney(float s) { money = s; }

    public static float Getspeed() { return speed; }
    public static void Setspeed(float s) { speed = s; }

    public static float Getscore() { return score; }
    public static void Setscore(float s) { score = s; }
}
