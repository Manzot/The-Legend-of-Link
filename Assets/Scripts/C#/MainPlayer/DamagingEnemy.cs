using UnityEngine;
using System.Collections;

public class DamagingEnemy : MonoBehaviour {

	public int damageToGiveByPlayer;
	private int currentDamage;
	//public GameObject BloodEffect;
	//public Transform HitPoint;

	private PlayerStats playerStats;

	void Update () 
	{
		playerStats = FindObjectOfType<PlayerStats> ();
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			//Destroy (other.gameObject);
			currentDamage = damageToGiveByPlayer + playerStats.currentAttack;
			other.gameObject.GetComponent<EnemyHealthManager>().EnemyDamage(currentDamage);
			//Instantiate(BloodEffect, HitPoint.position, HitPoint.rotation);
			//Destroy (BloodEffect, 1f);
		}
	}
}
