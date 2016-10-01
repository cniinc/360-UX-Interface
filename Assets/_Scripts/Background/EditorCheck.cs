using UnityEngine;
using System.Collections;
using UnityEngine.VR;
using UnityEngine.SceneManagement;

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
			#endif
			#if UNITY_EDITOR	
				GetComponent<SimpleSmoothMouseLook>().enabled = true;
				GetComponent<GvrHead> ().trackRotation = false;
				GetComponentInChildren<GvrViewer> ().VRModeEnabled = false;
			#endif



		}
	
	}

	public void StartTransitionToNewScene(string NextSceneName)
	{
		
		StartCoroutine (Transition (NextSceneName));
	}

	IEnumerator Transition(string NextScene)
	{
		VRFadeScreen VRFS = GetComponent<VRFadeScreen> ();
		VRFS.FadeOut (true);
		yield return new WaitForSeconds (VRFS.getFadeDuration ());
		SceneManager.LoadScene (NextScene);
	}

}
