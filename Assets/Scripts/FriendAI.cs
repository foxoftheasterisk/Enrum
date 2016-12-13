using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Makes Camera follow Main Character
public class FriendAI : MonoBehaviour {

	public GameObject leader; 
	public float stepspeed;
	Transform target;
	Vector3 targetCoordinates;
	Vector2 randomOffset;
	public float strayDistance=1;

	// Use this for initialization
	void Start () {
		SetNewTarget ();
	}

	// Update is called once per frame
	void Update () {			
	}

	void SetNewTarget(){
		//loop forever
			
		//follow the leader
		target = leader.transform;
		//add a random stray factor from the leader
		Vector2 randomOffset = Random.insideUnitCircle;
		targetCoordinates = new Vector3 (target.position.x + strayDistance * randomOffset.x, target.position.y + strayDistance * randomOffset.y, target.position.z);
		iTween.MoveTo (gameObject, iTween.Hash ("position", targetCoordinates, "time", 2, "onComplete", "SetNewTarget"));

		//wait specified time before calling again
		//yield return new WaitForSeconds(2);
	}
	void OnTriggerEnter (Collider target) {
		iTween.Stop ();
		//do what you want with collision
		if(target.tag == "Furniture"){
			//etc, etc
		}
	}

}
