using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveLoadManager : MonoBehaviour {

	public GameObject player;
	private PlayerHealthManager playerHP;
	private PlayerStats Stats;
	//private QuestManager quests;
	//private CutsceneDialogs CD;
//	private CutSceneTrigger CT;

	void Awake()
	{
		DontDestroyOnLoad(player);
	}

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		playerHP = FindObjectOfType<PlayerHealthManager>();
		Stats = FindObjectOfType<PlayerStats>();
		player.SetActive(true);
		//quests = FindObjectOfType<QuestManager> ();
	//	CD = FindObjectOfType<CutsceneDialogs> ();
		//CT = FindObjectOfType<CutSceneTrigger> ();
	}
	
	public void SaveState()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/saveGame.sav");

		PlayerData data = new PlayerData();

		data.posx = player.transform.position.x;
		data.posy = player.transform.position.y;
		data.currentHP = playerHP.playerCurrentHealth;
		data.MaxHP = playerHP.playerMaxHealth;
		data.MaxHPinStats = Stats.MaxHP;
		data.Attack = Stats.currentAttack;
		data.Defence = Stats.currentDefence;
		data.Level = Stats.currentLevel;
		data.Exp = Stats.currentExp;
		bf.Serialize(file , data);
		file.Close();
	}

	public void LoadState()
	{
		if(File.Exists(Application.persistentDataPath + "/saveGame.sav"))
		{

			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/saveGame.sav", FileMode.Open);

			PlayerData data = (PlayerData) bf.Deserialize(file);

			file.Close();
			player.transform.position = new Vector3(data.posx, data.posy);
			playerHP.playerCurrentHealth = data.currentHP;
			playerHP.playerMaxHealth = data.MaxHP;
			Stats.MaxHP = data.MaxHPinStats;
			Stats.currentAttack = data.Attack;
			Stats.currentDefence = data.Defence;
			Stats.currentLevel = data.Level;
			Stats.currentExp = data.Exp;
			player.SetActive(true);
			//CD.gameObject.SetActive (true);
			//CT.gameObject.SetActive (true);
			//cutScenes.NPCs[CD.eventID].gameObject.SetActive(true);
		}
	}
}


[Serializable]
class PlayerData
{
	public float posx;
	public float posy;
	public int currentHP;
	public int MaxHP;
	public int MaxHPinStats;
	public int Attack;
	public int Defence;
	public int Level;
	public int Exp;
}
