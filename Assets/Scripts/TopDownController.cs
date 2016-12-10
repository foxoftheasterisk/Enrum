using UnityEngine;
using System.Collections;

public class TopDownController : MonoBehaviour {

    Rigidbody2D physicsController;

	// Use this for initialization
	void Start () {
        physicsController = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 velocity = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.UpArrow))
            velocity += new Vector2(0, 0.5f);
        if (Input.GetKey(KeyCode.DownArrow))
            velocity += new Vector2(0, -0.5f);
        if (Input.GetKey(KeyCode.LeftArrow))
            velocity += new Vector2(-0.5f, 0);
        if (Input.GetKey(KeyCode.RightArrow))
            velocity += new Vector2(0.5f, 0);
        
        physicsController.velocity = velocity;

        if (velocity.magnitude != 0)
        {
            float targetRotation = Vector2.Angle(new Vector2(1, 0), velocity);
            if (velocity.y < 0)
                targetRotation = -targetRotation;
            if (physicsController.rotation != targetRotation)
            {

            }
        }
	}
}
