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
            velocity = physicsController.velocity;
        }
        else
            physicsController.velocity = velocity;

        
        
        if (velocity.magnitude != 0)
        {
            float targetRotation = Vector2.Angle(new Vector2(0, 1), velocity);
            if (velocity.x > 0)
                targetRotation = -targetRotation;
            if (physicsController.rotation != targetRotation)
            {
                float torque = targetRotation - physicsController.rotation;
                torque = torque % 360;
                if (torque < 0)
                    torque = 360 + torque;
                if (torque > 180)
                    torque = 360 - torque;
                torque = torque / 360;
                if (torque > 10)
                    torque = 10;
                if (torque < -10)
                    torque = -10;
                torque = torque * TORQUE_FACTOR;

                physicsController.AddTorque(torque);
            }
        }
        //*/
	}

    void OnGUI()
    {
        Vector2 velocity = physicsController.velocity;
        float targetRotation = Vector2.Angle(new Vector2(0, 1), velocity);
        if (velocity.x < 0)
            targetRotation = -targetRotation;

        GUI.Label(new Rect(10, 10, 100, 60), "Current rotation: " + physicsController.rotation + "\nTarget rotation: " + targetRotation);
    }
}
