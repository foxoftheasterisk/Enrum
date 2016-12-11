using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFollower : MonoBehaviour {

    public GameObject leader; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Transform pT = leader.GetComponent<Transform>();
        Transform tT = this.gameObject.GetComponent<Transform>();
        tT.position = new Vector3(pT.position.x, pT.position.y, tT.position.z);
	}
}
