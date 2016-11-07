using UnityEngine;
using System.Collections;

public class StreetCloner : MonoBehaviour {

	// "static" means "global", lives in the code
	// every clone will refer to this EXACT same variable
	public static int globalBuildingCount = 0;

	//	declare a private var, of type int, called stepCount, starting at 0
	int stepCount = 0;
	//	declare a public var, of type Transform, called streetMakerPrefab (+ assign Prefab in inspector)
	public Transform streetmakerPrefab;
	//	declare a public var, of type Transform, called buildingPrefab (+ assign Prefab in inspector)
	public Transform buildingPrefab;
	
	// Update is called once per frame
	void Update () {
//		// MOVEMENT: always move forward, relative to the direction I am facing
//		set [current position] plusequals [current forward direction] * 5f
		transform.position += transform.forward * 1.5f;
//
//		// BUILDING GENERATION: usually instantiate buildings, but sometimes instantiate StreetMakers +/- 90 degrees
//		declare a float called "randomNumber", set it equal to a random float between 0f and 100f
		float randomNumber = Random.Range(0f, 100f);
//
//		if "randomNumber" is less than 90f, then:
		if ( randomNumber < 90f ) { // 90% chance
// 			// make a new clone of the building, at current position, and current rotation
			Instantiate( buildingPrefab, transform.position, transform.rotation );
			globalBuildingCount++; // increment global count
			if ( globalBuildingCount > 1000 ) { // too many???
				Destroy( gameObject );
			}
		} else { // else: // 10% chance of making another street
//			declare a float called "anotherRandom", set it equal to a random float between 0f and 100f
			float anotherRandomNumber = Random.Range(0f, 100f);
//			if "anotherRandom" is less than 50f:
			if ( anotherRandomNumber < 50f ) {
//				... then instantiate a clone of streetMakerPrefab at [currentPosition] with an euler rotation (0, current Y euler angle - 90 degrees, 0)
				transform.Rotate(0f, 90f, 0f ); // turn 90 degrees
				Instantiate( streetmakerPrefab, transform.position, transform.rotation );
				transform.Rotate(0f, -90f, 0f); // turn back 90 degrees
			} else { // else:
//				... then instantiate a clone of streetMakerPrefab at [currentPosition] with an euler rotation (0, current Y euler angle + 90 degrees, 0)
				Instantiate( streetmakerPrefab, transform.position, Quaternion.Euler( 0f, transform.eulerAngles.y - 90f, 0f) );
			}
		}

//		// SELF-DESTRUCTION: self-destruct this StreetMaker if it has made enough buildings OR there is a building in front of it
//		add 1 to "stepCount"
		stepCount += 1;
//		if ["stepCount" is greater than or equal to 15]
		if ( stepCount >= 15 ) {
//		... then destroy [this gameObject]
			Destroy( gameObject );
		}

	}
}
