using UnityEngine;
using System.Collections;

public class CursorLock : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		// if the user clicks, then lock cursor
		// 0 = left click, 1 = right-click, 2=middle-click
		if ( Input.GetMouseButtonDown(0) ) {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
	}
}
