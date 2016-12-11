using UnityEngine;
using System.Collections;

public class TopDownController : MonoBehaviour {

    public bool onIce;
    public float TORQUE_FACTOR = 1;
    private Rigidbody2D physicsController;



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
        
        if(onIce)
        {
            physicsController.AddForce(velocity);
            //velocity = physicsController.velocity;
        }
        else
            physicsController.velocity = velocity;

        
        
        if (velocity.magnitude != 0)
        {
            float targetRotation = Vector2.Angle(new Vector2(0, 1), velocity);
            if (velocity.x > 0)
                targetRotation = -targetRotation;

            float currentRotation = physicsController.rotation % 360;
            if (currentRotation < 0)
                currentRotation = currentRotation + 360;
            if (currentRotation > 180)
                currentRotation = currentRotation - 360;

            if (physicsController.rotation != targetRotation)
            {
                float torque = targetRotation - currentRotation;
                if (torque < 0)
                    torque = torque + 360;
                if (torque > 180)
                    torque = torque - 360;

                torque = torque / 360;
                torque = -torque;

                torque = torque * TORQUE_FACTOR;

                physicsController.AddTorque(torque);
            }
        }
	}

    void OnGUI()
    {
       
    }
}
