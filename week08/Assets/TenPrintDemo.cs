using UnityEngine;
using System.Collections;

public class TenPrintDemo : MonoBehaviour {
	// variables to connect prefabs in the code
	public GameObject prefabA;
	public GameObject prefabB;

	int counter = 0;
	
	// Update is called once per frame
	void Update () {
		if ( counter < 30 ) {
			float randomNumber = Random.Range(0f, 100f);
			if ( randomNumber < 50f ) {
				// Transform newClone = (Transform)
				GameObject newClone = (GameObject)Instantiate( prefabA, 
					new Vector3( Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f) ),
					Quaternion.Euler( Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f) )
				);
				newClone.transform.localScale *= Random.Range(0f, 5f);
			} else {
				GameObject newClone2 = (GameObject)Instantiate( prefabB, 
					new Vector3( Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f) ),
					Quaternion.Euler( Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f) )
				);
				newClone2.GetComponent<Renderer>().material.color = Random.ColorHSV();
			}
			counter++;
		}


	}
}
