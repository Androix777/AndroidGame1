using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generationroom : MonoBehaviour {
    public string[] rooms;
    public float speedroom;
    public float speedup;
    public bool TestMode;
    GameObject Lastrom;
	// Use this for initialization
	void Awake () {
        RoomData.avgRoomAdd(1);
        if (TestMode) {
            // speedroom = Statsgame.Getspeed();
            Statsgame.Setspeed(speedroom);
            Statsgame.SetTestMode(true);
        }
        else { Createroom("Random");
            if (Statsgame.Getspeed() == 1) { Statsgame.Setspeed(speedroom); }
            else { speedroom = Statsgame.Getspeed(); }
            Statsgame.SetTestMode(false);
        }
        
        // i = 1;
        
	}

    private void FixedUpdate()
    {
		speedroom = speedroom + speedup;
		Statsgame.Setscore(Statsgame.Getscore()+speedroom/10);
		Statsgame.Setspeed(speedroom);
    }
    
    
    public void Createroom(string room)
    {if (room != "Random") {
        
        GameObject newroom = Instantiate(Resources.Load(room), new Vector3(45, 0, 0), transform.rotation)as GameObject; 
        
        
        }
        else
        {
            if (rooms.Length > 0)
            {int x=0,y=0;
               GameObject newroom = Instantiate(Resources.Load(RoomData.getRoom()), new Vector3(45, 0, 0), transform.rotation)as GameObject; 
                if (Random.Range(0,100)>50){x=180;}
        
        if (Random.Range(0,100)>50){y=180;}
        newroom.transform.rotation=Quaternion.Euler(x,y,0);
                }
        }
    }
    public void Lastroomset(GameObject r) { Lastrom = r; }
    public GameObject Lastroomget() {  return Lastrom; }
}

static class RoomData {
    static int[] dif1 = 
    {1};
    static int[] dif2 = 
    {2};
    static int[] dif3 = 
    {3};
    static int[] dif4 = 
    {4};
    static int[] dif5 = 
    {5};
    static int[] dif6 = 
    {6};
    static int[] dif7 = 
    {7};
    static int[] dif8 = 
    {8};
    static int[] dif9 = 
    {9};
    static int[] dif10 = 
    {10};
    static int num = 0;
    static int avgNeed = 5;
    static int sum = 0;
    static double avg = 0;
    static public void avgReset(){
        avgNeed = 0;
        num = 0;
    }
    static public int[] getArr(int x){
        switch(x){
            case 1:
            return (dif1);
            case 2:
            return (dif2);
            case 3:
            return (dif3);
            case 4:
            return (dif4);
            case 5:
            return (dif5);
            case 6:
            return (dif6);
            case 7:
            return (dif7);
            case 8:
            return (dif8);
            case 9:
            return (dif9);
            case 10:
            return (dif10);
            default:
            return(dif1);
        }
    }
    static public int getRand(int a, int b){
        int sum = 0;
        for(int i = a; i<=b; i++){
            sum += getArr(i).Length;
            
        }
        int rand = Random.Range(1,sum);
        sum = 0;
        for(int i = a; i<=b; i++){
            sum += getArr(i).Length;
            if (rand < sum) return i;
        }
        return 10;
    }
    static public void avgRoomAdd(int dif){
        sum += dif;
        num ++;
    }
    static public int avgRoomGet(){
        avg = (double)sum / num;
        if (avg > avgNeed){Debug.Log("+"); return(getRand(1, avgNeed));} else{Debug.Log("-");
        return(getRand(avgNeed,10));}
    }
    static public string getRoom(){
        int room = avgRoomGet();
        avgRoomAdd(room);
        Debug.Log(avg+" "+room);
        return convertNum(getArr(room)[Random.Range(0,dif1.Length)]);
    }
    
    static public string convertNum(int num ){
        int i=1;
        while (num/10>=1){
            i++;
            num/=10;
        }
        string ret="room-";
        for (int j=0;j<4-i;j++){
            ret+="0";
        }
        
        return ret+num.ToString();
    }
}