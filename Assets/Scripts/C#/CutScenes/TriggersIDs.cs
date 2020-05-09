using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggersIDs : MonoBehaviour {

	public int TriggerID;
	public bool AnimStart;
//	private CutTriggersManager CTM;

	private PlayerControls playerControls;




	// Use this for initialization
	void Start () 
	{
	//	CTM = FindObjectOfType<CutTriggersManager> ();
		playerControls = FindObjectOfType<PlayerControls>();
		AnimStart = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		

		//Debug.Log (tString);


	}
	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			playerControls.canMove = false;
			AnimStart = true;
		}
	}

	public void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			string tString = "CutScenesTrigger" + TriggerID.ToString();
			playerControls.canMove = true;
			AnimStart = false;
			GameObject.Find(tString).SetActive(false);
		}
	}
}
