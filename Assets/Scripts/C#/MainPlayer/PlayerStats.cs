using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {


	public int currentExp;
	public int currentLevel;

	public int [] ExpToLevelUp;
	public int [] HPLevels;
	public int [] AttackLevels;
	public int [] DefenceLevels;

	public int MaxHP;
	public int currentAttack;
	public int currentDefence;

	private PlayerHealthManager pHealthManager;
	// Use this for initialization
	void Start ()
	{
		pHealthManager = FindObjectOfType<PlayerHealthManager> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (currentExp >= ExpToLevelUp [currentLevel]) 
		{
			//currentLevel++;
			LevelUp();
		}
	}
	public void AddExperience(int expToAdd)
	{
		currentExp += expToAdd;
	}

	public void LevelUp()
	{
		currentLevel++;
		MaxHP = HPLevels [currentLevel];

		pHealthManager.playerMaxHealth = MaxHP;
		pHealthManager.playerCurrentHealth = MaxHP;

		currentAttack = AttackLevels [currentLevel];
		currentDefence = DefenceLevels [currentLevel];
	}
}
