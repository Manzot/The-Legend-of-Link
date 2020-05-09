using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DialogHolder : MonoBehaviour {
	
	//public string dialog;
	private DialogueManager dgmanager;
	
	public string[]dialogLines;
	public bool collideWithNPC;
	//private PlayerControls player;
	// Use this for initialization
	void Start () 
	{
		//player = FindObjectOfType<PlayerControls>();
		dgmanager = FindObjectOfType<DialogueManager> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
	
	public void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player" && dgmanager.DButton) 
		{
			if(dgmanager.DButton)
			{
				//Debug.Log("Collidededed");
				startDialogBox();
			}
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			dgmanager.DontShowDialogBox();
		}
	}
	public void startDialogBox()
	{
		//dgmanager.ShowDialogBox(dialog);
		if(!dgmanager.dialogActive)
		{
			dgmanager.dialogLines = dialogLines;
			dgmanager.currentLine = 0;
			dgmanager.ShowDialogues();
		}
		if(transform.parent.GetComponent<NpcManager>()!= null)
		{
			transform.parent.GetComponent<NpcManager>().canMove = false;
		}
		
	}
}
