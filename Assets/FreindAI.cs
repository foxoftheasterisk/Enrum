using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Makes Camera follow Main Character
public class FriendAI : MonoBehaviour {

	public GameObject leader; 
	public float stepspeed;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Transform pT = leader.GetComponent<Transform>();
		Transform tT = this.gameObject.GetComponent<Transform>();
		tT.position = new Vector3(pT.position.x, pT.position.y, tT.position.z);
		//iTween.MoveUpdate(gameObject, iTween.Hash("position", pT.position, "time", stepspeed));
	}
}
