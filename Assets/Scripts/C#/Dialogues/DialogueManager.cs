using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public GameObject dialogBox;
	public Text dialogText;
	
	public bool dialogActive;
	public bool DButton;
	public string []dialogLines;
	public int currentLine;

//	private DialogHolder dh;
	private BasicMovement keyboardMovements;
	private PlayerControls player;
	//private TouchController touchControls;
	
	// Use this for initialization
	void Start () 
	{
	//	dh = FindObjectOfType<DialogHolder> ();
		player = FindObjectOfType<PlayerControls> ();
	//	touchControls = FindObjectOfType<TouchController> ();
		keyboardMovements = FindObjectOfType<BasicMovement> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Using Keyboard
		if(dialogActive && Input.GetKeyDown(KeyCode.Space))
		{
			//dialogBox.SetActive(false);
			//dialogActive = false;
			currentLine++;
		}
		if (currentLine >= dialogLines.Length) 
		{
			dialogBox.SetActive(false);
			dialogActive = false;
			currentLine = 0;
			keyboardMovements.canMove = true;
			player.canMove = true;
		}
		dialogText.text = dialogLines[currentLine];
	}

	
	public void ShowDialogues()
	{
		dialogActive = true;
		dialogBox.SetActive (true);
		keyboardMovements.canMove = false;
		player.canMove = false;
	}
	
	public void DontShowDialogBox()
	{
		dialogActive = false;
		dialogBox.SetActive (false);
		keyboardMovements.canMove = true;
		player.canMove = true;
	}
	public void LinePlus()
	{
		if(dialogActive)
		{
			currentLine++;
		}

	}
	public void OnTouch()
	{
		if(!dialogActive)
		{
			DButton = true;
		}
	}
	public void LeaveTouch()
	{
		DButton = false;
	}
}
