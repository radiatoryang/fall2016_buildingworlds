using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

public class SimpleRestart : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		// Unity 5.3 or earlier
//		if ( Input.GetKeyDown(KeyCode.R) ) {
//			Application.LoadLevel( Application.loadedLevel );
//		}

		// Unity 5.4 or later, "more correct" way
		if ( Input.GetKeyDown(KeyCode.R) ) {
			SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
		}
	}
}
