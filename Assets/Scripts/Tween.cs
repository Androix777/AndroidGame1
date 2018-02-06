using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tween : MonoBehaviour {
	public enum anim {Move, Rotate, Scale}
    public anim type;
	public float speed;
	public bool  loopRestart, curvedPath;
	public Vector3 rotateVector = new Vector3(0f,0f,1000000f), scaleVector;
    public Vector3[] points;
	LoopType myLoopType;
	PathType myPathType;



	void Start () {
        speed = speed * Statsgame.Getspeed()  / 100;
		DOTween.Init ();
		switch (type)
		{
		case anim.Move:

			if (points.Length > 0)
			{
				myLoopType = LoopType.Yoyo;
				if (loopRestart) {myLoopType = LoopType.Restart;}
				myPathType = PathType.Linear;
				if (curvedPath) {myPathType = PathType.CatmullRom;}
				transform.DOLocalPath (points, speed, myPathType, PathMode.Ignore).SetSpeedBased().SetLoops(-1, myLoopType).SetEase(Ease.Linear).SetId("It is a trap");
			}                
			break;

		case anim.Rotate:
			myLoopType = LoopType.Yoyo;
			if (loopRestart) {myLoopType = LoopType.Restart;}
			transform.DOLocalRotate (rotateVector, speed, RotateMode.FastBeyond360).SetSpeedBased().SetLoops(-1, myLoopType).SetEase(Ease.Linear).SetId("It is a trap");
			break;

		case anim.Scale:
			
			myLoopType = LoopType.Yoyo;
			if (loopRestart) {myLoopType = LoopType.Restart;}
			myPathType = PathType.Linear;
			if (curvedPath) {myPathType = PathType.CatmullRom;}
			transform.DOScale (scaleVector, speed).SetSpeedBased().SetLoops(-1, myLoopType).SetEase(Ease.Linear).SetId("It is a trap");              
			break;
		}
    }
}
