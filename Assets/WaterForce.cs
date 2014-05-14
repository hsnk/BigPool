using UnityEngine;
using System.Collections;

public class WaterForce : MonoBehaviour {

	private float maxRotX = 1f;
	private float maxRotZ = 1f;
	
	private Vector3 buoyancyCenter;
	
	private float height;

	private float damp;
	
	private float forceScaler;
	
	private Vector3 actionPoint;

	private Vector3 upLift;

	// Use this for initialization
	void Start () {
		height = 1f;
		damp = 0.3f;
		buoyancyCenter = new Vector3 (0, 1, 0);
		maxRotX = 1f;
		maxRotZ = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		actionPoint = transform.position + transform.TransformDirection (buoyancyCenter);
		forceScaler = 10f * (1f - (actionPoint.y / height));

		if (forceScaler > 0f) {
			upLift = - Physics.gravity * (forceScaler - rigidbody.velocity.y * damp);
			rigidbody.AddForceAtPosition(upLift, actionPoint);
		}
	}

	void FixedUpdate () {
		Vector3 angleRot = transform.eulerAngles;
		print (transform.eulerAngles);
		if (!(angleRot.x >= (360-maxRotX) || angleRot.x <= maxRotX)) {
			if (Mathf.Abs((360-maxRotX) - angleRot.x) > Mathf.Abs(maxRotX - angleRot.x)) {
				angleRot.x = maxRotX;
			} else {
				angleRot.x = (360-maxRotX) ;
			}
		}
		if (!(angleRot.z >= (360-maxRotZ) || angleRot.z <= maxRotX)) {
			if (Mathf.Abs((360-maxRotZ) - angleRot.z) > Mathf.Abs(maxRotZ - angleRot.z)) {
				angleRot.z = maxRotX;
			} else {
				angleRot.z = (360-maxRotZ) ;
			}
		}
		transform.eulerAngles =  new Vector3(0f, angleRot.y, angleRot.z);
	}
}
