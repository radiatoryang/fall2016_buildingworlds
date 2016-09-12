using UnityEngine;
using System.Collections;

public class RotateCube : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		// if the user holds down LeftArrow then do this...
		if ( Input.GetKey(KeyCode.LeftArrow) ) {
			transform.Rotate(0f, 5f, 0f); // rotate 5 degrees on X axis
		}

		// if the user holds down RightArrow then rotate 5 degrees other way
		if ( Input.GetKey(KeyCode.RightArrow) ) {
			transform.Rotate(0f, -5f, 0f);
		}
	}
}
