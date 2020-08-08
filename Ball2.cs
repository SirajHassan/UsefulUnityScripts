using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2 : MonoBehaviour
{
    public enum BallType { RED };
    public BallType ballType = BallType.RED;
	public AudioSource Sound;
	public GameObject PointMeter;
	public GameObject PointGoal;
	

	public Transform hiddenTarget;

    Vector3 startPosition = Vector3.zero;
    bool hidden = false;
	public float collisionTimer; // to control multiple collisions
	public bool collisionBool = false; // to control multiple collisions





	// Start is called before the first frame update
	void Start()
    {
        startPosition = transform.position;
	    Sound = GetComponent<AudioSource> ();
		PointGoal = GameObject.Find("PointGoal");

        //set Point goal at 3m
		Vector3 pgCurrentPos = PointGoal.transform.position;
		pgCurrentPos.y = 3;
		PointGoal.transform.position = pgCurrentPos;

		collisionTimer = Time.time;






	}

    // Update is called once per frame
    void Update()
    {
		Vector3 currentPosition = transform.position;

		if (currentPosition.y < 0 && !hidden)
        {
            Rigidbody rigidBody = GetComponent<Rigidbody>();
            rigidBody.position = startPosition;
            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = Vector3.zero;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
		
		PointMeter = GameObject.Find("PointMeter");

		float timeElapsed = Time.time - collisionTimer; 

		if (other.name == "Military target" && timeElapsed > 1) //collisions cannot happen within one second of eachother...
		{
		    
		    collisionTimer = Time.time;
			collisionBool = true;

            if (ballType == BallType.RED)
            {
                
				Sound.Play(); // sound of ball hitting target

                // raise point meter 1/2 meter
				
				Vector3 pmCurrentPos = PointMeter.transform.position;
				Debug.Log("In OnTriggerEnter");
				pmCurrentPos.y += 0.5f;
				//Debug.Log("In OnTriggerEnter Rise");
				PointMeter.transform.position = pmCurrentPos;


				Rigidbody rigidBody = GetComponent<Rigidbody>();
                rigidBody.position = startPosition;
                rigidBody.velocity = Vector3.zero;
                rigidBody.angularVelocity = Vector3.zero;
                
            }
            else
            {
                hidden = true;
                Rigidbody rigidBody = GetComponent<Rigidbody>();
                rigidBody.position = hiddenTarget.position;
                rigidBody.velocity = Vector3.zero;
                rigidBody.angularVelocity = Vector3.zero;
            }

			//collisionBool = true;
        }
    }
}
