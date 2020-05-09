using UnityEngine;
using System.Collections;

public class QuestTrigger : MonoBehaviour {

	private QuestManager QM;

	public int questID;
	public bool startQuest;
	public bool endQuest;
	// Use this for initialization
	void Start () {
		QM = FindObjectOfType<QuestManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			if(!QM.questCompleted[questID])
			{
				if(startQuest && !QM.quests[questID].gameObject.activeSelf)
				{
					QM.quests[questID].gameObject.SetActive(true);
					QM.quests[questID].StartQuest();
				}
				if(endQuest && QM.quests[questID].gameObject.activeSelf)
				{
					QM.quests[questID].EndQuest();
				}
			}
		}
	}
}
