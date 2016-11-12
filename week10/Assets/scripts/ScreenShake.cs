using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour {

	public float shakeStrength = 0f;
	Vector3 startPosition;

	void Start () {
		startPosition = transform.position; // remember start pos before we started shaking
	}

	void Update () {
		// let us press SPACEBAR to trigger the shake
		if ( Input.GetKey( KeyCode.Space ) ) {
			shakeStrength = 10f;
		}
		// every frame always make shakeStrength go 10% of the way toward 0 ("decay")
		shakeStrength += (0f - shakeStrength) * 0.1f; // from Juice It Or Lose It video, "x += (target - x) * 0.1"

		// before we shake the camera, let's calculate where we want the camera to shake
		Vector3 cameraShake = new Vector3(0f, 0f, 0f);
		// multiple INSIDE SINE to make it faster... multiple OUTSIDE SINE to increase distance
		// add left-right motion to cameraShake
		cameraShake = transform.right * Mathf.Sin( Time.time * 20f ) * 0.1f;
		// add up-down motion to cameraShake
		cameraShake += transform.up * Mathf.Sin( Time.time * 17f ) * 0.06f;

		// now is when we actually apply shaking motion to the current position
		transform.position = startPosition + cameraShake * shakeStrength;
		// we start with "startPosition" so that the camera does not drift away
		// imagine shakeStrength was 0f... then "transform.position = startPosition", which is what we want, the camera to go back to where it started
	}
}
