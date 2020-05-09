using UnityEngine;
using System.Collections;

public class QuestDetails : MonoBehaviour {

	public int questID;

	public QuestManager QM;

	public string []startText;
	public string []endText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartQuest()
	{
		QM.showQuestTexts (startText);
	}
	public void EndQuest()
	{
		QM.showQuestTexts (endText);
		QM.questCompleted [questID] = true;
		gameObject.SetActive(false);
	}
}
