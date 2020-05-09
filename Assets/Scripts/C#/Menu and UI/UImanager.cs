using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UImanager : MonoBehaviour {

	public Slider HealthBar;
	public PlayerHealthManager playerHealth;
	public Text HPText;
	public Text LevelText;
	private PlayerStats playerStats;

	// Use this for initialization
	void Start () 
	{
		playerStats = GetComponent<PlayerStats> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		HealthBar.maxValue = playerHealth.playerMaxHealth;
		HealthBar.value = playerHealth.playerCurrentHealth;
		HPText.text = playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;
		LevelText.text = "Lvl:" + playerStats.currentLevel;
	}
}
