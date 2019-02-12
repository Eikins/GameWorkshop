using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	public float rotationSpeed = 5.0f;
	
	void Update () {	
		Vector3 r = new Vector3(0, rotationSpeed, 0) * Time.deltaTime;
		transform.Rotate(r);
	}
	
}
