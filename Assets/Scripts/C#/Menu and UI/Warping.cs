using UnityEngine;
using System.Collections;

public class Warping : MonoBehaviour {

	public Transform warpTarget;

	IEnumerator OnTriggerEnter2D(Collider2D other)
	{
		ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();

		yield return StartCoroutine(sf.FadeToBlack());

		other.gameObject.transform.position = warpTarget.position;
		Camera.main.transform.position = warpTarget.position;

		yield return StartCoroutine(sf.FadeToClear());
	}


}
