using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class EditorCheck : MonoBehaviour {
	bool firstUpdateFrame = true;
	/*
	 * a series of simple functions to streamline functions.
	 */

	// Use this for initialization
	void Update () {

		if (firstUpdateFrame) {
			firstUpdateFrame = false;
			#if UNITY_ANDROID

				GetComponent<SimpleSmoothMouseLook> ().enabled = false;
				Debug.Log ("Turning off SimpleSmoothMouseLook because " + VRDevice.model + " detected");

			#endif
			#if UNITY_EDITOR	
			GetComponent<SimpleSmoothMouseLook>().enabled = true;
				GetComponent<GvrHead> ().trackRotation = false;
				GetComponentInChildren<GvrViewer> ().VRModeEnabled = false;
			#endif



		}
	
	}

}
