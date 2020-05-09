using UnityEngine;
using System.Collections;

public class QuestManager : MonoBehaviour {

	public QuestDetails[] quests;
	public bool [] questCompleted;

	public string[] textLines;

	public DialogueManager DM;
	// Use this for initialization
	void Start () 
	{
		questCompleted = new bool[quests.Length];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void showQuestTexts(string []questText)
	{
		DM.dialogLines = questText;
		//DM.dialogLines [0] = questText;

		DM.currentLine = 0;
		DM.ShowDialogues ();
	}
}
