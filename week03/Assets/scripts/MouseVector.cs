using UnityEngine;
using System.Collections;

public class MouseVector : MonoBehaviour {

	public float mouseX, mouseY;
	
	// Update is called once per frame
	void Update () { 
		// "mouse deltas"
		// if we don't move the mouse, it's equal to 0
		mouseX = Input.GetAxis( "Mouse X" );
		mouseY = Input.GetAxis( "Mouse Y" );

		// move object based on current mouseSpeed
		// this will be 0,0,0 if the mouse stays still
		// transform.position = new Vector3( mouseX, 0f, mouseY );

		// move object, but ON TOP of previous position
		transform.position += new Vector3( mouseX, 0f, mouseY );

		// clamp position inside an area
		transform.position = new Vector3( 
			Mathf.Clamp( transform.position.x, -5f, 5f), 
			transform.position.y, 
			Mathf.Clamp( transform.position.z, -5f, 5f) 
		);

	}
}
