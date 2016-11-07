using UnityEngine;
using System.Collections;

public class Streetmaker : MonoBehaviour {

	public Transform buildingPrefab, makerPrefab;

	int counter = 0;
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0f, 0f, Random.Range(1f, 2f) );

		float randomnumber = Random.value;

//		if ( Random.value > 0.8f ) {
//			transform.Rotate(0f, 90f, 0f);
//		} else if ( Random.value > 0.6f) {
//			transform.Rotate(0f, -90f, 0f);
//		}

		if ( Random.value < 0.95f ) {
				Instantiate( buildingPrefab, transform.position + transform.right, Quaternion.identity );
		Instantiate( buildingPrefab, transform.position - transform.right, Quaternion.identity );
		} else {
			if ( Random.value > 0.5f ) {
				Instantiate( makerPrefab, transform.position + transform.right, Quaternion.Euler(0f, transform.localEulerAngles.y + 90f, 0f) );
			} else {
				Instantiate( makerPrefab, transform.position - transform.right, Quaternion.Euler(0f, transform.localEulerAngles.y - 90f, 0f) );
			}
		}

		counter++;
		if ( counter >= 15 ) {
			Destroy( this.gameObject );
		}
	}
}
