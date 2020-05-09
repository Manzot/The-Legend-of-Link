using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Checkpoints : MonoBehaviour {

	private SaveLoadManager SaveLoadM;
	public GameObject SavingAnimation;
	public bool GameSaving;
	// Use this for initialization
	void Start () {
		SaveLoadM = FindObjectOfType<SaveLoadManager> ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		StartCoroutine (SaveAnim());
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			Debug.Log ("Game Saved");
			SaveLoadM.SaveState ();
			GameSaving = true;
		} 
	}
	private IEnumerator SaveAnim()
	{
		if (GameSaving) {
			
			SavingAnimation.SetActive (true);

			yield return new WaitForSeconds (2f);

			SavingAnimation.SetActive (false);

			GameSaving = false;
		}
	}
}
