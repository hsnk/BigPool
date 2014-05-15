using UnityEngine;
using System.Collections;

public class SimpleWaterForce : MonoBehaviour {
	
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
}
