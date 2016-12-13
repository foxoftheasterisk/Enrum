using UnityEngine;
using System.Collections;

public class FollowPath : MonoBehaviour
{	
	public string pathName;
	public int travelTime;
	//public float travelSpeed;
	public string loopType;
	void Start(){
		iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath(pathName), "time", travelTime, "looptype", loopType, "easetype", "linear"));
	}
}
