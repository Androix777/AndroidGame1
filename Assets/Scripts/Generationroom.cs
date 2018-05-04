using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Generationroom : MonoBehaviour {
    public string[] rooms;
    public int[] roomad;
    public int minDif,maxDif;
    public float speedroom,avg;
    public float speedup;
    public bool TestMode;
    GameObject Lastrom;
    public GameObject[,] allrooms;
	// Use this for initialization
	void Awake () {
        RoomData.avgReset();
         allrooms=new GameObject[0,0];
       // if (Statsgame.Getavg()!=-1){avg=Statsgame.Getavg();}
        if (Statsgame.Getmindif()!=-1){minDif=Statsgame.Getmindif();}
        if (Statsgame.Getmaxdif()!=-1){maxDif=Statsgame.Getmaxdif();}
        avg=minDif;
        RoomData.Setdif(minDif,maxDif,(maxDif+avg)/2);
        
        allrooms=new GameObject[maxDif-minDif+1,20];
        int z=0;
        for (int i=minDif;i<=maxDif;i++){
            for (int j=1;j<=RoomData.dif[i];j++){
            GameObject newroom = Instantiate(Resources.Load(RoomData.convertNum(i,j)), new Vector3(100,100, 100) ,transform.rotation)as GameObject;  
            newroom.SetActive(false);
            allrooms[i-minDif,j]=newroom;
        }
        z++;
                            }       
        
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
        
        
        roomad=new int[maxDif-minDif];
	}

    private void FixedUpdate()
    {
		speedroom = speedroom + speedup;
		Statsgame.Setscore(Statsgame.Getscore()+speedroom/10);
		
    }


    public void Createroom(string room)
    {
        if (room != "Random")
        {
            GameObject newroom = Instantiate(Resources.Load(room), new Vector3(0, 45, 0), transform.rotation) as GameObject;
        }
        else
        {
            if (rooms.Length > 0)
            {
                int x = 0, y = 0;
                GameObject newroom = Instantiate(RoomData.getRoom(ref allrooms), new Vector3(0, 45, 0), transform.rotation) as GameObject;
                newroom.SetActive(true);
                newroom.transform.localEulerAngles = new Vector3(0, 0, 90);
                if (Random.Range(0, 100) > 50)
                {
                    if (Random.Range(0, 100) > 50)
                    {
                        newroom.transform.localRotation = Quaternion.Euler(180, 180, 90);
                    }
                    else
                    {
                        newroom.transform.localRotation = Quaternion.Euler(180, 0, 90);
                    }
                }
                else
                {
                    if (Random.Range(0, 100) > 50)
                    {
                        newroom.transform.localRotation = Quaternion.Euler(0, 180, 90);
                    }
                    else
                    {
                        newroom.transform.localRotation = Quaternion.Euler(0, 0, 90);
                    }
                }
                //newroom.transform.localRotation= Quaternion.Euler(180,0,0);
                //Debug.Log(newroom.name+" "+ newroom.transform.localEulerAngles); 
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
    public static int[] dif={1,5,3,8,9,13,13,13,2,1,1};
    static int maxDif,minDif;
    static int num = 0;
    static float avgNeed = 5;
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
        if (avg > avgNeed){ return(getRand(minDif, (int)avgNeed));} else{
        return(getRand((int)avgNeed,maxDif));}
    }
    static public GameObject getRoom(ref GameObject[,] allrooms){
        int room = avgRoomGet();
        avgRoomAdd(room);
        int r=Random.Range(1,dif[room]+1);
        //Debug.Log(avg+" "+room+" "+avgNeed+" "+r);

        return allrooms[room-minDif,r];
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

static public void Setdif(int a,int b,float setavg){
avgNeed=setavg;
minDif=a;
maxDif=b;

}
}