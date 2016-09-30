using UnityEngine;
using System.Collections;

// COMPUTER SCIENCE TERM TO GOOGLE IF YOU WANT TO KNOW MORE: "Model View Controller" or MVC

public class DroneController : MonoBehaviour {

	public GameObject droneObject;
	public GameObject capsuleObject;


	// FixedUpdate is where PHYSICS happens
	void FixedUpdate () {
		// hold down SPACE to add force
		if ( Input.GetKey( KeyCode.Space ) ) {
			droneObject.GetComponent<Rigidbody>()
				.AddForce( droneObject.transform.forward * 10f );
		}

		if ( Input.GetKey(KeyCode.LeftArrow ) ) {
			// GetComponent<Transform>()... is like saying "transform..."
			droneObject.GetComponent<Transform>().Rotate( 0f, -5f, 0f );
		}
		if ( Input.GetKey(KeyCode.RightArrow ) ) {
			droneObject.transform.Rotate( 0f, 5f, 0f );
		}
	}
}
