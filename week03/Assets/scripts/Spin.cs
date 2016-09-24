using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		// rotate 90 degrees on Y axis per second
		transform.Rotate(0f, 90f * Time.deltaTime, 0f );
	}
}
