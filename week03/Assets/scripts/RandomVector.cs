using UnityEngine;
using System.Collections;

public class RandomVector : MonoBehaviour {

	public float speed = 5f; // when you put "public" in front of a var, it shows up in Unity

	float lastTimeWhenIMoved = 0f;
	Vector3 myDestination; // remember where I want to move
	
	// Update is called once per frame
	void Update () {
		// transform.position = new Vector3( 1f, 1f, 4.20f );

		// set a new destination
		if ( Time.time > lastTimeWhenIMoved + 1f ) { // wait 1 second
			myDestination = new Vector3( Random.Range( -2f, 2f), 
										 Random.Range(-2f, 2f), 
										 Random.Range(-2f, 4.20f) 
									   );
			lastTimeWhenIMoved = Time.time; // update last time when I moved
		}

		// ok let's actually move now
		transform.position = Vector3.MoveTowards( transform.position,
												  myDestination,
												  Time.deltaTime * speed
												);

	} // end of Update()
}
