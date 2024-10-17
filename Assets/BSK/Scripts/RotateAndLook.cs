using UnityEngine;
using System.Collections;

public class RotateAndLook : MonoBehaviour {
	
	//This script is for camera oin menu scene to rotate around the target
	public Transform target;
	public float speed = 10;
	
	
	public float angleLimit = 30f; // Maximum angle to rotate

	private float currentAngle = 0f;

	void Update()
	{
		// Calculate the angle with Mathf.PingPong to loop between -angleLimit and +angleLimit
		currentAngle = Mathf.PingPong(Time.time * speed, angleLimit * 2) - angleLimit;

		// Rotate the camera around the target by the calculated angle
		transform.position = target.position + Quaternion.Euler(0, currentAngle, 0) * Vector3.back * 10f;

		// Make the camera look at the target
		transform.LookAt(target.position);
	}
	/*void Update () {
		transform.RotateAround(target.position, Vector3.up, speed * Time.deltaTime);
		transform.LookAt(target.position);
	}*/
}
