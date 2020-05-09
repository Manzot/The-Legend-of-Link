using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutscenesManager : MonoBehaviour {


	public DialogueManager DM;

	private Animator anim;

	private Cutscenedialogs CD;

	private CutTriggersManager CTM;

	private TriggersIDs Tid;

	public bool PauseBool;

	public string[] AnimationNames;


	void Start () 
	{
		anim = GetComponent <Animator> ();
		CD = FindObjectOfType<Cutscenedialogs> ();
		CTM = FindObjectOfType<CutTriggersManager> ();
		Tid = FindObjectOfType<TriggersIDs> ();
		PauseBool = false;
	}


	void Update () 
	{

		if (CTM.AnimBool [Tid.TriggerID] && Tid.AnimStart) 
		{
			PauseBool = true;
		//	anim.SetBool ("NoAnimation", false);
			anim.SetBool ("FirstCutscene", true);
		}
		else 
		{
			anim.SetBool ("NoAnimation", true);
			anim.SetBool ("FirstCutscene", false);
		}
			
		if (PauseBool && DM.currentLine > CD.DialogValue) 
		{
			anim.enabled = true;
		}

	}


	// At Dialog time
	public void StartScene()
	{
		showCutsceneTexts (CD.CutsceneDialogs);
	}

	//A pause for dialogs
	public void PauseScene()
	{
		anim.enabled = false;
	}

	//For Ending function 
	public void EndScene()
	{
		PauseBool = false;
		CTM.AnimBool [Tid.TriggerID] = false;
		Tid.AnimStart = false;
	}

	//Dialog Manager
	public void showCutsceneTexts(string []cutsceneText)
	{
		DM.ShowDialogues ();
		DM.currentLine = 0;
		DM.dialogLines = cutsceneText;
	}
}

