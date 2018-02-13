using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Generationroom : MonoBehaviour {
    public string[] rooms;
    public int avg,minDif,maxDif;
    public float speedroom;
    public float speedup;
    public bool TestMode;
    GameObject Lastrom;
	// Use this for initialization
	void Awake () {
        RoomData.avgReset();
        if (Statsgame.Getavg()!=-1){avg=Statsgame.Getavg();}
        if (Statsgame.Getmindif()!=-1){minDif=Statsgame.Getmindif();}
        if (Statsgame.Getmaxdif()!=-1){maxDif=Statsgame.Getmaxdif();}
        RoomData.Setdif(minDif,maxDif,avg);
        
        
        RoomData.avgRoomAdd(1);
        if (TestMode) {
            
            Statsgame.Setspeed(speedroom);
            Statsgame.SetTestMode(true);
        }
        else { Createroom("Random");
            if (Statsgame.Getspeed() == 0) { Statsgame.Setspeed(speedroom); }
            else { speedroom = Statsgame.Getspeed(); }
            Statsgame.SetTestMode(false);
        }
        
        
        
	}

    private void FixedUpdate()
    {
		speedroom = speedroom + speedup;
		Statsgame.Setscore(Statsgame.Getscore()+speedroom/10);
		
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

    public void StopAll(){           
            speedroom = 0;
            speedup = 0;
            DOTween.Pause("It is a trap");  
            Statsgame.Setspeed(0);       
    }



}

static class RoomData {
    static int[] dif={0,3,1,4,1,6,5,8,1,0,0};
    static int maxDif,minDif;
    static int num = 0;
    static int avgNeed = 5;
    static int sum = 0;
    static double avg = 0;
    static public void avgReset(){
        avgNeed = 0;
        num = 0;
        sum=0;
        avg=0;
    }
    
    static public int getRand(int a, int b){
        int sum = 0;
        for(int i = a; i<=b; i++){
            sum += dif[i];
            
        }
        int rand = Random.Range(1,sum);
        sum = 0;
        for(int i = a; i<=b; i++){
            sum += dif[i];
            if (rand <= sum) return i;
        }
        return 10;
    }
    static public void avgRoomAdd(int dif){
        sum += dif;
        num ++;
    }
    static public int avgRoomGet(){
        avg = (double)sum / num;
        if (avg > avgNeed){ return(getRand(minDif, avgNeed));} else{
        return(getRand(avgNeed,maxDif));}
    }
    static public string getRoom(){
        int room = avgRoomGet();
        avgRoomAdd(room);
        Debug.Log(avg+" "+room);
        return convertNum(room,Random.Range(1,dif[room]+1));
    }
    
    static public string convertNum(int diff, int num ){
        int i=1;
        int nums=num;
        while (nums/10>=1){
            i++;
            nums/=10;
        }
        string zero="room-";
        for (int j=0;j<4-i;j++){
            zero+="0";
        }
        
        return "Dif"+diff+"/"+zero+num;
    }

static public void Setdif(int a,int b,int setavg){
avgNeed=setavg;
minDif=a;
maxDif=b;
}
}